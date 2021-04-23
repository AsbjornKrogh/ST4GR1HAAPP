using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public interface IClinicDB
    {
        //UC 3.2
        Patient GetPatient(string CPR);

        //UC3.3
        bool SaveTechnicalSpec(TecnicalSpec techSpec);

        //UC3.4
        bool DeleteHA(string CPR);

        //UC4
        Patient GetPatientInformations(string EarCastID);

        TecnicalSpec GetEarScan(string CPR);

        List<TecnicalSpec> GetEarScans();

        //List<ProcesSpec> GetProcesInfo(string CPR); 

        bool SaveScan(RawEarScan scan);

    }
}
