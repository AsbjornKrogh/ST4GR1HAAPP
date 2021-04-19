using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Clinician;
using EFCoreTestConsoleApp;

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


        
        public void SaveUpdates(string email, int phonenumber)
        {

            
        }

        public void SavePatientPressed(Patient patient, string email, int phonenumber)
        {
            patient.zipcode = phonenumber;
            clinicDatabase.UpdatePatient(patient);
        }

        public bool FindCPR(string CPRnumber)
        {
            foreach (var patient in clinicDatabase.GetAllPatients())
            {
                if (patient.CPR == CPRnumber)
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
