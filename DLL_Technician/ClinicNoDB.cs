using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CoreEFTest;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public class ClinicNoDB:IClinicDB
    {

        public Patient GetPatient(string CPR)
        {
            Thread.Sleep(3000);

            if (CPR == "123456-7891")
            {
                Patient testPatient = new Patient();
                testPatient.CPR = "123456-7891";
                testPatient.Name = "Børge";
                testPatient.Lastname = "Andersen";
                testPatient.Age = 69;
                return testPatient;
            }
            else
            {
                return null;
            }
            
            
        }

        public bool DeleteHA(string CPR)
        {
            return true;
        }
    }
}
