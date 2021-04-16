using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Technician;

namespace BLL_Technician
{
    public class UC4_Scan
    {
        private IClinicDB clinicDB;
        private NoScanner scanner;

        public UC4_Scan(IClinicDB clinicDb)
        {
            clinicDB = clinicDb;
        }

        public Patient GetPatientInformations(string EarCastID)
        {
            return clinicDB.GetPatientInformations(EarCastID);
        }

        public bool ConnectToScanner()
        {
            return scanner.connectTo3DScanner();
        }
    }
}
