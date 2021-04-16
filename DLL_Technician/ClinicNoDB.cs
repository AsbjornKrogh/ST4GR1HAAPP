using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public class ClinicNoDB:IClinicDB
    {

        public Patient GetPatient(string CPR)
        {
            Patient testPatient = new Patient();
            testPatient.CPR = "123456-7891";
            testPatient.Name = "Børge";
            return testPatient;
        }

        public bool DeleteHA(string CPR)
        {
            return true;
        }
    }
}
