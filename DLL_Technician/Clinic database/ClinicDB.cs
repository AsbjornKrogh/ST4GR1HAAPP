using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreEFTest.Context;
using CoreEFTest.Models;
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
         Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);

         return patient;
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
            _dbContext.TecnicalSpecs.Add(techSpec);
            _dbContext.SaveChanges();
         }
         catch
         {
            return false;
         }

         return _dbContext.TecnicalSpecs.Contains(techSpec);
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
            TecnicalSpec Techspec = _dbContext.TecnicalSpecs.Single((x => x.CPR == CPR && x.EarSide == rawEarPrint.EarSide));

            rawEarPrint.HATechnicalSpecID = Techspec.HATechinalSpecID;

            _dbContext.RawEarPrints.Add(rawEarPrint);
            _dbContext.SaveChanges();
         }
         catch
         {
            return false;
         }

         return _dbContext.RawEarPrints.Contains(rawEarPrint);
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
         int earCastId = Convert.ToInt32(EarCastID);
         EarCast earCast = _dbContext.EarCast.Single(x => x.EarCastID == earCastId);
         Patient patient = GetPatient(earCast.PatientCPR);

         return patient;
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
            TecnicalSpec Techspec = _dbContext.TecnicalSpecs.Single((x => x.CPR == CPR && x.EarSide == scan.EarSide));

            scan.HATechnicalSpecID = Techspec.HATechinalSpecID;

            _dbContext.RawEarScans.Add(scan);
            _dbContext.SaveChanges();
         }
         catch
         {
            return false;
         }

         return _dbContext.RawEarScans.Contains(scan);
      }

      /// <summary>
      /// Der hentes et earscan fra DB ud fra et specifikt CPR.
      /// Metoden returnerer en liste der indeholder scanning for både venstre og højre øre.
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public List<TecnicalSpec> GetEarScan(string CPR)
      {
         //Henter TechSpec for V og H øre
         TecnicalSpec TechspecL = _dbContext.TecnicalSpecs.Single((x => x.CPR == CPR && x.EarSide == Ear.Left));
         TecnicalSpec TechspecR = _dbContext.TecnicalSpecs.Single((x => x.CPR == CPR && x.EarSide == Ear.Right));

         //Henter Earscan for V og H øre 
         TechspecL.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecL.HATechinalSpecID);
         TechspecR.RawEarScan = _dbContext.RawEarScans.Single(x => x.HATechnicalSpecID == TechspecR.HATechinalSpecID);

         //Henter generelsepc for Techspec
         TechspecL.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == TechspecL.HAGenerelSpec);
         TechspecR.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == TechspecR.HAGenerelSpec);

         //Oprettelse af listen
         List<TecnicalSpec> Techspec = new List<TecnicalSpec>(2);
         //Tilføjelse af techspec objekterne til listen 
         Techspec.Add(TechspecL); Techspec.Add(TechspecR);

         //Return the list;
         return Techspec;
      }

      /// <summary>
      /// Benyttes til at returnere en liste med alle earscan fra DB der endnu ikke er printet.
      /// </summary>
      /// <returns></returns>
      public List<TecnicalSpec> GetEarScans()
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
               tecnicalSpec.GeneralSpec = _dbContext.GeneralSpecs.Single(x => x.HAGeneralSpecID == tecnicalSpec.HAGenerelSpec);
               TechSpeclist.Add(tecnicalSpec);
            }
         }

         //return. 
         return TechSpeclist;
      }
   }
}
