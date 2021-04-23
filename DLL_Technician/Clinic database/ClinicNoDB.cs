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
        #region UC3.2 Show patient
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
        #endregion

        #region UC3.3 Update 

        public bool SaveTechnicalSpec(TecnicalSpec techSpec)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UC3.4 Delete patient
        public bool DeleteHA(string CPR)
        {
            return true;
        }
        #endregion

        #region UC4 scan
        public Patient GetPatientInformations(string EarCastID)
        {
            Thread.Sleep(3000);

            if (EarCastID == "R-1")
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

        public TecnicalSpec GetEarScan(string CPR)
        {
            throw new NotImplementedException();
        }

        public List<TecnicalSpec> GetEarScans()
        {
            throw new NotImplementedException();
        }

        public bool SaveScan(RawEarScan scan)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
