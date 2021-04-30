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

        public bool SaveScan(RawEarScan scan, string CPR)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region UC5 print



        public List<TecnicalSpec> GetEarScan(string CPR)
        {
            List<TecnicalSpec> tecnicalSpecs = new List<TecnicalSpec>();
            //Thread.Sleep(3000);

            if (CPR == "123456-7891")
            {
                TecnicalSpec testTecnicalSpec1 = new TecnicalSpec();
                testTecnicalSpec1.CPR = "123456-7891";
                //testTecnicalSpec1.Patient.Name = "Børge";
                //testTecnicalSpec1.Patient.Lastname = "Andersen";
                testTecnicalSpec1.EarSide = Ear.Right;
                //testTecnicalSpec1.Patient.Age = 69;
                tecnicalSpecs.Add(testTecnicalSpec1);

                TecnicalSpec testTecnicalSpec2 = new TecnicalSpec();
                testTecnicalSpec2.CPR = "123456-7891";
                //testTecnicalSpec2.Patient.Name = "Børge";
                //testTecnicalSpec2.Patient.Lastname = "Andersen";
                testTecnicalSpec2.EarSide = Ear.Left;
                //testTecnicalSpec2.Patient.Age = 69;
                tecnicalSpecs.Add(testTecnicalSpec2);

                return tecnicalSpecs;

            }
            else
            {
                return null;
            }
        }

        public List<TecnicalSpec> GetEarScans()
        {
            List<TecnicalSpec> tecnicalSpecs = new List<TecnicalSpec>();
            Thread.Sleep(3000);
            
                TecnicalSpec testTecnicalSpec1 = new TecnicalSpec();
                testTecnicalSpec1.CPR = "123456-7891";
                //testTecnicalSpec1.Patient.Name = "Børge";
                //testTecnicalSpec1.Patient.Lastname = "Andersen";
                testTecnicalSpec1.EarSide = Ear.Right;
                //testTecnicalSpec1.Patient.Age = 69;
                tecnicalSpecs.Add(testTecnicalSpec1);

                TecnicalSpec testTecnicalSpec2 = new TecnicalSpec();
                testTecnicalSpec2.CPR = "123456-7891";
                //testTecnicalSpec2.Patient.Name = "Børge";
                //testTecnicalSpec2.Patient.Lastname = "Andersen";
                testTecnicalSpec2.EarSide = Ear.Left;
                //testTecnicalSpec2.Patient.Age = 69;
                tecnicalSpecs.Add(testTecnicalSpec2);

                return tecnicalSpecs;
            }
        #endregion
        
    }
}
