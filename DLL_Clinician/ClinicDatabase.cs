using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreEFTest.Context;
using CoreEFTest.Models;
using Microsoft.EntityFrameworkCore;


namespace DLL_Clinician
{
    public class ClinicDatabase: IClinicDatabase
    {
        private readonly PatientContext _dbContext;

        public ClinicDatabase(PatientContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Patient
        /// <summary>
        /// Denne metode benyttes til at hente alle Patienter fra ClinicDatabase
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAllPatients()
        {
            List<Patient> Patient = _dbContext.Patient.ToList();

            return Patient;
        }

        /// <summary>
        /// Denne metode benyttes til at hente en specifik Patient fra ClinicDatabase, ud fra deres CPR
        /// </summary>
        /// <param name="CPR"></param>
        /// <returns></returns>
        public Patient GetPatient(string CPR)
        {
            Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);

            return patient;
        }

        /// <summary>
        /// Denne metode benyttes til at hente en specifik Patient med knyttede EarCast fra ClinicDatabase, ud fra deres CPR
        /// </summary>
        /// <param name="CPR"></param>
        /// <returns></returns>

        public Patient GetPatientWithEarCast(string CPR)
        {
            Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);
            patient.EarCasts = _dbContext.EarCast.Where(x => x.PatientCPR == CPR).ToList();

            return patient;
        }

        /// <summary>
        /// Denne metode benyttes til at oprette en specifik Patient i ClinicDatabase.
        /// </summary>
        /// <param name="patient"></param>
        public void CreatePatient(Patient patient)
        {
            _dbContext.Patient.Add(patient);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Denne metode benyttes til at slette en specifik Patient i ClinicDatabase.
        /// </summary>
        /// <param name="patient"></param>
        public void DeletePatient(Patient patient)
        {
            _dbContext.Patient.Remove(patient);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Denne metode benyttes til at updatere en specifik Patient i ClinicDatabase.
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
    }
}
