using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Clinician;
using EFCoreTestConsoleApp;
using Microsoft.EntityFrameworkCore.Internal;

namespace BLL_Clinician
{
    public class UC2_ManagePatient
    {
        private IClinicDatabase clinicDatabase;
        bool CPRCorrect;
        

        public UC2_ManagePatient()
        {
            clinicDatabase = new ClinicDatabase();
        }


        
        public void SaveUpdates(Patient patient)
        {

            clinicDatabase.UpdatePatient(patient);
        }

        public void SavePatientPressed(Patient patient)
        {
            clinicDatabase.CreatePatient(patient);
            
        }

        //public void SavePatientPressed(Patient patient, string email, int phonenumber)
        //{
        //    //patient.zipcode = phonenumber;
        //    clinicDatabase.UpdatePatient(patient);
        //}

        public bool CheckCPR(string CPRnumber)
        {
            int patientRegistered = 0;
            foreach (var patient in clinicDatabase.GetAllPatients())
            {
                if (patient.CPR == CPRnumber)
                {
                    patientRegistered++;
                }

                if (patientRegistered == 1)
                {
                    CPRCorrect = true;
                }
                else
                {
                    CPRCorrect = false;
                }
            }
            return CPRCorrect;
        }


        public Patient GetPatientInformation(string CPRnumber)
        {
            return clinicDatabase.GetPatient(CPRnumber);
        }
    }
}
