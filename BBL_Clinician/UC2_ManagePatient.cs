using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Clinician;
using DLL_Clinician.RegionsDatabase;
using EFCoreTestConsoleApp;
using Microsoft.EntityFrameworkCore.Internal;

namespace BLL_Clinician
{
    public class UC2_ManagePatient
    {
        private IClinicDatabase clinicDatabase;
        private IRegionDatabase regionDatabase;
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

        public bool CheckCPRClinicDatabase(string CPRnumber)
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

        public bool CheckCPRRegionDatabase(string CPRnumber)
        {
            if (regionDatabase.CheckCPR(CPRnumber))
            {
                CPRCorrect = true;
            }
            else
            {
                CPRCorrect = false;
            }

            return CPRCorrect;
        }

        public Patient GetPatientInformationRegionsDatbase(string CPRnumber)
        {
            return regionDatabase.GetPatient(CPRnumber);
        }

        public Patient GetPatientInformation(string CPRnumber)
        {
            return clinicDatabase.GetPatient(CPRnumber);
        }
    }
}
