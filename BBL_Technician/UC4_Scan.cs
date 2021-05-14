using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Technician;
using DTO;

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

        public RawEarScan StartScanning(Ear Earside)
        {
            return scanner.StartScanning(Earside);
        }

        public bool SaveScan(RawEarScan scan, string CPR)
        {
            return clinicDB.SaveScan(scan, CPR);
        }

        public bool CreateTechnicalSpec(string CPR, int ScanTechID, Ear earSide)
        {
            TecnicalSpec techSpec = new TecnicalSpec();
            techSpec.CPR = CPR;
            techSpec.StaffID = ScanTechID;
            techSpec.Printed = false;
            techSpec.EarSide = earSide; 

            return clinicDB.SaveTechnicalSpec(techSpec);
        }
    }
}
