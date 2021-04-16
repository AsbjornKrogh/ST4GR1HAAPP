using System;
using System.Collections.Generic;
using System.Text;
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

        //public bool SavePatientPressed(RegionPatient patient, string email, int phonenumber)
        //{
        //    return true;
        //}

        public bool CPR_Registered(string CPRnumber)
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
    }
}
