using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreEFTest.Context;
using CoreEFTest.Models;
using DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DLL_Technician
{
   public class ClinicDB : IClinicDB
   {
      private readonly ClinicDBContext _dbContext;

      public ClinicDB(ClinicDBContext dbContext)
      {
         _dbContext = dbContext;
      }

      /// <summary>
      /// Metoden bliver benyttet til at hente en patient fra DB der passer til det pågældende CPR
      /// og returnere et patient objekt.
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public Patient GetPatient(string CPR)
      {
         try
         {
            Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);

            return patient;
         }
         catch
         {
            return null;
         }
      }

      /// <summary>
      /// Metoden bliver benyttet til at hente en patient fra DB der passer til det pågældende CPR
      /// og det nyeste technical- og generalspec for hvert øre fra databasen tilhørende patienten 
      /// og returnere et patient objekt.
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public Patient GetPatientWithGeneralSpecAndTechnicalSpec(string CPR)
      {
         try
         {
            Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);

            TecnicalSpec TechspecL = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Left);
            TecnicalSpec TechspecR = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Right);

            patient.TecnicalSpecs = new List<TecnicalSpec>() { TechspecL, TechspecR};

            GeneralSpec GenSpecL = _dbContext.GeneralSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Left && x.HAGeneralSpecID == TechspecL.HAGenerelSpecID);
            GeneralSpec GenSpecR = _dbContext.GeneralSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Right && x.HAGeneralSpecID == TechspecR.HAGenerelSpecID);

            patient.GeneralSpecs = new List<GeneralSpec>() { GenSpecL, GenSpecR };
            return patient;
         }
         catch
         {
            return null;
         }
      }

      /// <summary>
      /// Metoden benyttes til at gemme en TechinalSpec, og returnere efterfølgende en bool
      /// hvorvidt den er gemt i DB eller ej
      /// </summary>
      /// <param name="techSpec"></param>
      /// <returns></returns>
      public bool SaveTechnicalSpec(TecnicalSpec techSpec)
      {
         try
         {
            GeneralSpec generalSpec = _dbContext.GeneralSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == techSpec.CPR && x.EarSide == techSpec.EarSide);

            techSpec.HAGenerelSpecID = generalSpec.HAGeneralSpecID;

            _dbContext.TecnicalSpecs.Add(techSpec);
            _dbContext.SaveChanges();

            return _dbContext.TecnicalSpecs.Contains(techSpec);
         }
         catch
         {
            return false;
         }
      }

      /// <summary>
      /// Der gemmes et specifikt rawEarScan i DB og efterfølgende returneres en bool som fortæller om det er gjort.
      /// </summary>
      /// <param name="rawEarPrint"></param>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public bool SavePrint(RawEarPrint rawEarPrint, string CPR)
      {
         try
         {
            //Henter specifik techspec tilhørende det givne RawEarPrint og CPR. 
            TecnicalSpec Techspec = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == rawEarPrint.EarSide);

            //Sætter id i RawEarPrint
            rawEarPrint.HATechnicalSpecID = Techspec.HATechinalSpecID;

            //Gemmer RawEarPrint
            _dbContext.RawEarPrints.Add(rawEarPrint);
            _dbContext.SaveChanges();

            // Sætter printed parameteren til true
            Techspec.Printed = true;

            _dbContext.TecnicalSpecs.Update(Techspec);
            _dbContext.SaveChanges();

            return _dbContext.RawEarPrints.Contains(rawEarPrint);
         }
         catch
         {
            return false;
         }
      }

      /// <summary>
      /// Er ikke implementeret. 
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public bool DeleteHA(string CPR)
      {
         return false;
      }

      /// <summary>
      /// ID på earcast bliver brugt til at hente informationer omkring en patient.
      /// Den patient som passer med det specifikke earcast ID returneres.
      /// </summary>
      /// <param name="EarCastID"></param>
      /// <returns></returns>
      public Patient GetPatientInformations(string EarCastID)
      {
         try
         {
            int earCastId = Convert.ToInt32(EarCastID);
            EarCast earCast = _dbContext.EarCast.Single(x => x.EarCastID == earCastId);
            Patient patient = GetPatientWithGeneralSpecAndTechnicalSpec(earCast.PatientCPR);

            patient.EarCasts.Add(earCast); 

            return patient;
         }
         catch
         {
            return null;
         }
      }


      /// <summary>
      /// Der gemmes et specikt earscan i DB og efterfølgende returneres en bool som fortæller om det er gjort.
      /// </summary>
      /// <param name="scan"></param>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public bool SaveScan(RawEarScan scan, string CPR)
      {
         try
         {
            //Find det specifikke scans techspec
            TecnicalSpec Techspec = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last((x => x.CPR == CPR && x.EarSide == scan.EarSide));

            scan.HATechnicalSpecID = Techspec.HATechinalSpecID;

            _dbContext.RawEarScans.Add(scan);
            _dbContext.SaveChanges();

            RawEarScan rawEarScan = _dbContext.RawEarScans.OrderBy(x => x.ScanDate).Last(x => x.HATechnicalSpecID == Techspec.HATechinalSpecID && x.EarSide == Techspec.EarSide);

            Techspec.ScanID = rawEarScan.ScanID;

            _dbContext.TecnicalSpecs.Update(Techspec);

            return _dbContext.RawEarScans.Contains(scan);
         }
         catch
         {
            return false;
         }
      }

      public bool UpdateGeneralspec(GeneralSpec generalSpec)
      {
         try
         {
            _dbContext.GeneralSpecs.Update(generalSpec);
            return _dbContext.GeneralSpecs.Contains(generalSpec);
         }
         catch
         {
            return false;
         }
       

   
      }

      /// <summary>
      /// Der hentes et earscan fra DB ud fra et specifikt CPR.
      /// Metoden returnerer en liste der indeholder scanning for både venstre og højre øre.
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public List<TecnicalSpec> GetTechnicalSpecs(string CPR)
      {
         try
         {
            //Henter TechSpec for V og H øre
            TecnicalSpec TechspecL = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Left);
            TecnicalSpec TechspecR = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Right);

            //Henter Earscan for V og H øre 
            TechspecL.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecL.HATechinalSpecID);
            TechspecR.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecR.HATechinalSpecID);

            //Henter generelsepc for Techspec
            TechspecL.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == TechspecL.HAGenerelSpecID);
            TechspecR.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == TechspecR.HAGenerelSpecID);

            //Oprettelse af listen
            List<TecnicalSpec> Techspec = new List<TecnicalSpec>(2);

            //Tilføjelse af techspec objekterne til listen 
            Techspec.Add(TechspecL); Techspec.Add(TechspecR);

            //Return the list;
            return Techspec;
         }
         catch
         {
            return null;
         }
      }

      /// <summary>
      /// Benyttes til at returnere en liste med alle earscan fra DB der endnu ikke er printet.
      /// </summary>
      /// <returns></returns>
      public List<TecnicalSpec> GetEarScans()
      {
         try
         {
            //Henter alle techSpec ud af DB'en
            List<TecnicalSpec> DBlist = _dbContext.TecnicalSpecs.ToList();

            //Oprettelse af listen, som skal returneres
            List<TecnicalSpec> TechSpeclist = new List<TecnicalSpec>();

            //For hver techspec som er i listen hentet fra database, tjekkes der på om Prited = false
            foreach (TecnicalSpec tecnicalSpec in DBlist)
            {
               //Hvis Printed = false, hentes generalspec og det tilknyttede Earscan
               //og lægges i techspec objektet og objektet tilføjes returneringslisten
               if (!tecnicalSpec.Printed)
               {
                  tecnicalSpec.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == tecnicalSpec.HATechinalSpecID);
                  tecnicalSpec.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == tecnicalSpec.HAGenerelSpecID);
                  TechSpeclist.Add(tecnicalSpec);
               }
            }
            return TechSpeclist;
         }
         catch
         {
            return null;
         }
      }

      /// <summary>
      /// Henter Process informationerne til det give CPR. Metoden vil altid hente de nyeste informationer. 
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public List<ProcesSpec> GetProcesInfo(string CPR)
      {

         List<ProcesSpec> procesSpecs = new List<ProcesSpec>();
         ProcesSpec procesSpecL = new ProcesSpec();
         ProcesSpec procesSpecR = new ProcesSpec();

         try
         {
            //Venstre
            //Henter generalspec
            GeneralSpec generalSpecL = _dbContext.GeneralSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Left);
            if (generalSpecL.CreateDate != null)
            {
               procesSpecL.GeneralSpecCreateDateTime = generalSpecL.CreateDate;
               procesSpecL.ClinicianId = generalSpecL.StaffID;
               TecnicalSpec TechspecL = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.HAGenerelSpecID == generalSpecL.HAGeneralSpecID);

               //Henter techspec
               if (TechspecL.CreateDate != null)
               {
                  procesSpecL.TechSpecCreateDateTime = TechspecL.CreateDate;
                  procesSpecL.TechnicalId = TechspecL.StaffID;
                  procesSpecL.Printed = procesSpecL.Printed;

                  //Henter EarScan
                  TechspecL.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecL.HATechinalSpecID);
                  if (TechspecL.RawEarScan != null)
                  {
                     procesSpecL.scanTechId = TechspecL.StaffID;
                     procesSpecL.scanDateTime = TechspecL.CreateDate;
                  }

                  //Henter Earprint
                  if (procesSpecL.Printed)
                  {
                     RawEarPrint rawEarPrint = _dbContext.RawEarPrints.OrderBy(x => x.PrintDate).Last(x => x.HATechnicalSpecID == TechspecL.HATechinalSpecID && x.EarSide == Ear.Left);
                     ;
                     procesSpecL.PrintDateTime = rawEarPrint.PrintDate;
                     procesSpecL.PrintTechId = rawEarPrint.StaffID;
                  }
               }
            }

            procesSpecs.Add(procesSpecL);


            //Højre
            //Henter GeneralSpec
            GeneralSpec generalSpecR = _dbContext.GeneralSpecs.OrderBy(x => x.CreateDate).Last(x => x.CPR == CPR && x.EarSide == Ear.Right);
            if (generalSpecR.CreateDate != null)
            {
               procesSpecR.GeneralSpecCreateDateTime = generalSpecR.CreateDate;
               procesSpecR.ClinicianId = generalSpecR.StaffID;
               TecnicalSpec TechspecR = _dbContext.TecnicalSpecs.OrderBy(x => x.CreateDate).Last(x => x.HAGenerelSpecID == generalSpecR.HAGeneralSpecID);

               //Henter techspec
               if (TechspecR.CreateDate != null)
               {
                  procesSpecR.TechSpecCreateDateTime = TechspecR.CreateDate;
                  procesSpecR.TechnicalId = TechspecR.StaffID;
                  procesSpecR.Printed = procesSpecR.Printed;

                  //Henter EarScan
                  TechspecR.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecR.HATechinalSpecID);
                  if (TechspecR.RawEarScan != null)
                  {
                     procesSpecR.scanTechId = TechspecR.StaffID;
                     procesSpecR.scanDateTime = TechspecR.CreateDate;
                  }

                  //Henter Earprint
                  if (procesSpecR.Printed)
                  {
                     RawEarPrint rawEarPrint = _dbContext.RawEarPrints.OrderBy(x => x.PrintDate).Last(x => x.HATechnicalSpecID == TechspecR.HATechinalSpecID && x.EarSide == Ear.Right);
                     procesSpecR.PrintDateTime = rawEarPrint.PrintDate;
                     procesSpecR.PrintTechId = rawEarPrint.StaffID;
                  }
               }
            }

            procesSpecs.Add(procesSpecR);

            return procesSpecs;
         }
         catch
         {
            return null;
         }
      }
   }
}
