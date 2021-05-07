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
        private Random random = new Random();

        #region UC3.2 Show patient
        public Patient GetPatientWithGeneralSpecAndTechnicalSpec(string CPR)
        {
            Thread.Sleep(3000);

            if (CPR == "123456-7891")
            {
                Patient testPatient = new Patient();
                testPatient.CPR = "123456-7891";
                testPatient.Name = "Børge";
                testPatient.Lastname = "Andersen";
                testPatient.Age = 69;

                testPatient.TecnicalSpecs = new List<TecnicalSpec>();

                TecnicalSpec testTecnicalSpecLeft = new TecnicalSpec();
                testTecnicalSpecLeft.EarSide = Ear.Left;

                TecnicalSpec testTecnicalSpecRight = new TecnicalSpec();
                testTecnicalSpecRight.EarSide = Ear.Right;
                testTecnicalSpecRight.Printed = true;

                testPatient.TecnicalSpecs.Add(testTecnicalSpecLeft);
                testPatient.TecnicalSpecs.Add(testTecnicalSpecRight);

                testPatient.GeneralSpecs = new List<GeneralSpec>();

                GeneralSpec testGeneralSpecLeft = new GeneralSpec();
                testGeneralSpecLeft.Color = PlugColor.Almond;
                testGeneralSpecLeft.Type = Material.Silhuet;

                GeneralSpec testGeneralSpecRight = new GeneralSpec();
                testGeneralSpecRight.Color = PlugColor.Honey;
                testGeneralSpecRight.Type = Material.Blød;

                testPatient.GeneralSpecs.Add(testGeneralSpecLeft);
                testPatient.GeneralSpecs.Add(testGeneralSpecRight);

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
            Thread.Sleep(1000);

            if (EarCastID == "R-1")
            {
                Patient testPatient = new Patient();
                testPatient.CPR = "123456-7891";
                testPatient.Name = "Børge";
                testPatient.Lastname = "Andersen";
                testPatient.Age = 69;

                testPatient.TecnicalSpecs = new List<TecnicalSpec>();

                TecnicalSpec testTecnicalSpecLeft = new TecnicalSpec();
                testTecnicalSpecLeft.EarSide = Ear.Left;
                testTecnicalSpecLeft.RawEarScan = new RawEarScan();

                TecnicalSpec testTecnicalSpecRight = new TecnicalSpec();
                testTecnicalSpecRight.EarSide = Ear.Right;
                testTecnicalSpecRight.Printed = true;

                testTecnicalSpecRight.RawEarScan = new RawEarScan();

                testPatient.TecnicalSpecs.Add(testTecnicalSpecLeft);
                testPatient.TecnicalSpecs.Add(testTecnicalSpecRight);


                testPatient.GeneralSpecs = new List<GeneralSpec>();

                GeneralSpec testGeneralSpecLeft = new GeneralSpec();
                testGeneralSpecLeft.Color = PlugColor.Almond;
                testGeneralSpecLeft.Type = Material.Silhuet;

                GeneralSpec testGeneralSpecRight = new GeneralSpec();
                testGeneralSpecRight.Color = PlugColor.Honey;
                testGeneralSpecRight.Type = Material.Blød;

                testPatient.GeneralSpecs.Add(testGeneralSpecLeft);
                testPatient.GeneralSpecs.Add(testGeneralSpecRight);

                return testPatient;
            }
            else
            {
                return null;
            }
        }

        public bool SaveScan(RawEarScan scan, string CPR)
        {
            Thread.Sleep(1000);
            int trigger = random.Next(1, 10);

            if (trigger > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion


        #region UC5 print



        public List<TecnicalSpec> GetTechnicalSpecs(string CPR)
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
                testTecnicalSpec1.RawEarScan = new RawEarScan();
                tecnicalSpecs.Add(testTecnicalSpec1);


                TecnicalSpec testTecnicalSpec2 = new TecnicalSpec();
                testTecnicalSpec2.CPR = "123456-7891";
                //testTecnicalSpec2.Patient.Name = "Børge";
                //testTecnicalSpec2.Patient.Lastname = "Andersen";
                testTecnicalSpec2.EarSide = Ear.Left;
                //testTecnicalSpec2.Patient.Age = 69;
                testTecnicalSpec2.RawEarScan = new RawEarScan();
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
                testTecnicalSpec1.RawEarScan = new RawEarScan(); 
                tecnicalSpecs.Add(testTecnicalSpec1);

                TecnicalSpec testTecnicalSpec2 = new TecnicalSpec();
                testTecnicalSpec2.CPR = "123456-7891";
                //testTecnicalSpec2.Patient.Name = "Børge";
                //testTecnicalSpec2.Patient.Lastname = "Andersen";
                testTecnicalSpec2.EarSide = Ear.Left; 
                //testTecnicalSpec2.Patient.Age = 69;
                testTecnicalSpec2.RawEarScan = new RawEarScan();
                tecnicalSpecs.Add(testTecnicalSpec2);

                return tecnicalSpecs;
            }
        #endregion
        
    }
}
