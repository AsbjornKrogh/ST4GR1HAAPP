using System.Collections.Generic;
using CoreEFTest.Models;

namespace DLL_Clinician
{
    public interface IClinicDatabase
    {
        List<Patient> GetAllPatients();

        Patient GetPatient(string CPR);

        Patient GetPatientWithEarCast(string CPR);

        void CreatePatient(Patient patient);

        void DeletePatient(Patient patient);

        void UpdatePatient(Patient patient);

        //UC3
        List<GeneralSpec> GetAlleGeneralSpecs(string CPR);

        void UpdateGeneralSpec(GeneralSpec generalSpec);

        //muligvis - men skal ikke laves endnu
        //GetHearingTestPDF(string CPR)
        


        //UC6
        //List<ProcesSpec> GetProcesInfo(string CPR); 



    }
}