using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;


namespace DLL_Clinician
{
    class ClinicDatabase : IClinicDatabase
    {


        public bool CheckCPR(string CPRnumber)
        {
            return true;
        }

        public void GetPatientInformation(string CPRnumber)
        {

            
        }


        //public bool SavePatient(Patient patient)
        //{

        //}


    }
}
