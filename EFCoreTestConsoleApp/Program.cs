using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using CoreEFTest.Context;
using CoreEFTest.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace EFCoreTestConsoleApp
{
   class Program
   {
      static void Main(string[] args)
      {
         ClinicDBContext dbContext = new ClinicDBContext();
         ClinicianDBLogic clinicianDbLogic = new ClinicianDBLogic(dbContext);

         #region Create (CRUD)

         #region Create patient
         //Patient newPatient = new Patient()
         //{
         //   CPR = "110396-0000",
         //   Name = "Maja Louise",
         //   Lastname = "Enevoldsen",
         //   Adress = "Hallovej 15",
         //   zipcode = 8200,
         //   Age = 25,
         //   City = "Aarhus N",
         //   EyeColor = "Brun"
         //};

         // clinicianDbLogic.CreatePatient(newPatient);


         #endregion

         #region Create EarCast

         //Patient newCastPatient = clinicianDbLogic.GetPatient("250997-0000");
         //newCastPatient.EarCasts.Add(new EarCast(){Ear = 'R'});
         //clinicianDbLogic.UpdatePatient(newCastPatient);


         #endregion

         #region Create EarCast 2

         EarCast newCast = new EarCast()
         {
            PatientCPR = "250997-0000",
            Ear = 'L',
         };

         clinicianDbLogic.CreateEarCast(newCast);

         #endregion

         #endregion

         #region Delete (CRUD)

         #region Delete patient

         //Patient DeletePatient = new Patient()
         //{
         //   CPR = "110396-0000",
         //};

         //clinicianDbLogic.DeletePatient(DeletePatient);

         #endregion

         #region Delete EarCast

         //EarCast DeleteEarCast = new EarCast()
         //{
         //   EarCastID = 2,
         //};

        // clinicianDbLogic.DeleteEarCast(DeleteEarCast);

         #endregion
         #endregion

         #region Update (CRUD)

         #region Update patient

         //Patient UpdatePatient = new Patient()
         //{
         //   CPR = "110396-0000",
         //   Lastname = "Nedergaard Enevoldsen",
         //   Adress = "Trøjbordvej 72",

         //};

         //clinicianDbLogic.UpdatePatient(UpdatePatient);

         #endregion
         #endregion

         #region Retrive (CRUD)

         #region Retrieve Alle patienter 
         //List<Patient> Patients = clinicianDbLogic.GetAllPatients();

         //foreach (Patient patient in Patients)
         //{
         //   Console.WriteLine(patient.Name);
         //}
         #endregion

         #region Retrieve Patient tilhørende øre afstøbning
         //Patient Patient = clinicianDbLogic.GetPatientFromEarCast(2);

         //Console.WriteLine(Patient.Name);

         #endregion

         #region Create afstøbning
         //EarCast earCast = clinicianDbLogic.Get
         //Patient Patient = clinicianDbLogic.GetPatient("250997-0000");

        // Console.WriteLine(Patient.Name);

         #endregion

         #region Retrieve Patient tilhørende øre afstøbning

         Patient earPatient = clinicianDbLogic.GetPatientWithEarCast("250997-0000");

         foreach (EarCast earPatientEarCast in earPatient.EarCasts)
         {
            Console.WriteLine($"CPR: {earPatientEarCast.PatientCPR} Øre side: {earPatientEarCast.Ear} ID: {earPatientEarCast.EarCastID}");
         }

         #endregion



         #endregion

      }
   }

   internal class ClinicianDBLogic
   {
      private readonly ClinicDBContext _dbContext;

      public ClinicianDBLogic(ClinicDBContext dbContext)
      {
         _dbContext = dbContext;
      }

      #region Patient
      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
      public List<Patient> GetAllPatients()
      {
         List<Patient> Patient = _dbContext.Patient.ToList();

         return Patient;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public Patient GetPatient(string CPR)
      {
         Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);
         
         return patient;
      }
      
      public Patient GetPatientWithEarCast(string CPR)
      {
         Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);
         patient.EarCasts = _dbContext.EarCast.Where(x => x.PatientCPR == CPR).ToList();

         return patient;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="patient"></param>
      public void CreatePatient(Patient patient)
      {
         _dbContext.Patient.Add(patient);
         _dbContext.SaveChanges();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="patient"></param>
      public void DeletePatient(Patient patient)
      {
         _dbContext.Patient.Remove(patient);
         _dbContext.SaveChanges();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="patient"></param>
      public void UpdatePatient(Patient patient)
      {
         Patient DBpatient = _dbContext.Patient.Find(patient.CPR);
         if (DBpatient != null)
         {
            if (DBpatient.Name != patient.Name && patient.Name != null)
            {
               DBpatient.Name = patient.Name;
            }

            if (DBpatient.Lastname != patient.Lastname && patient.Lastname != null)
            {
               DBpatient.Lastname = patient.Lastname;
            }

            if (DBpatient.Adress != patient.Adress && patient.Adress != null)
            {
               DBpatient.Adress = patient.Adress;
            }

            if (DBpatient.City != patient.City && patient.City != null)
            {
               DBpatient.City = patient.City;
            }

            if (DBpatient.zipcode != patient.zipcode && patient.zipcode != 0)
            {
               DBpatient.zipcode = patient.zipcode;
            }

            if (DBpatient.Age != patient.Age && patient.Age != 0)
            {
               DBpatient.Age = patient.Age;
            }

            if (DBpatient.EarCasts != patient.EarCasts && patient.EarCasts != null)
            {
               DBpatient.EarCasts = patient.EarCasts;
            }

            _dbContext.Patient.Update(DBpatient);
         }

         _dbContext.SaveChanges();
      }
      #endregion


      //------------------------------------------------------------------------------------------------
      //------------------------------------------------------------------------------------------------



      #region EarCast
      /// <summary>
      /// 
      /// </summary>
      /// <param name="earCast"></param>
      public void CreateEarCast(EarCast earCast)
      {
         try
         {
            Patient patient = _dbContext.Patient.Single(x => x.CPR == earCast.PatientCPR);
            
            _dbContext.EarCast.Add(earCast);
            _dbContext.SaveChanges();
         }
         catch (Exception e)
         {
          
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="earCastID"></param>
      /// <returns></returns>
      public Patient GetPatientFromEarCast(int earCastID)
      {
         EarCast earCast = _dbContext.EarCast.Single(x => x.EarCastID == earCastID);
         Patient patient = GetPatient(earCast.PatientCPR);

         return patient;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="earCast"></param>
      public void DeleteEarCast(EarCast earCast)
      {
         _dbContext.EarCast.Remove(earCast);
         _dbContext.SaveChanges();
      }

      #endregion

   }
}
