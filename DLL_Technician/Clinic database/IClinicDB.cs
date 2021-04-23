using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public interface IClinicDB
    {
        Patient GetPatient(string CPR);

        bool DeleteHA(string CPR);

        Patient GetPatientInformations(string EarCastID);

        TecnicalSpec GetEarScan(string CPR);

        List<TecnicalSpec> GetEarScans();

        //List<ProcesSpec> GetProcesInfo(string CPR); 

    }
}
