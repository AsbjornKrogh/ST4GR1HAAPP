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
        private IScanner scanner;

        public UC4_Scan(IClinicDB clinicDb, IScanner scanner)
        {
            clinicDB = clinicDb;
            this.scanner = scanner;
        }

        public Patient GetPatientInformations(string EarCastID)
        {
            return clinicDB.GetPatientInformations(EarCastID);
        }

        public bool ConnectToScanner()
        {
            return scanner.connectTo3DScanner();
        }

        public RawEarScan StartScanning(int ScanTechID)
        {
            return scanner.StartScanning(ScanTechID);
        }
    }
}
