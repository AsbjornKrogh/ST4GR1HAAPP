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

        public bool CreateTechnicalSpec(Patient patient, StaffLogin ScanTechID, Ear earSide)
        {
            TecnicalSpec techSpec = new TecnicalSpec();
            techSpec.CPR = patient.CPR;
            techSpec.Patient = patient;
            techSpec.StaffID = ScanTechID.StaffID;
            techSpec.StaffLogin = ScanTechID; 
            techSpec.Printed = false;
            techSpec.EarSide = earSide; 
            techSpec.CreateDate = DateTime.Now;

            //null values
            techSpec.EarPrints = new List<RawEarPrint>();
            techSpec.RawEarScan = new RawEarScan();
            techSpec.ScanID = 0;
           
            return clinicDB.SaveTechnicalSpec(techSpec);
        }
    }
}
