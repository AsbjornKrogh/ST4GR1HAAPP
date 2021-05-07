using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Technician;

namespace BLL_Technician
{
    public class UC3_UpdateHATech
    {
        private IClinicDB clinicDB;

        public UC3_UpdateHATech(IClinicDB clinicDB)
        {
            this.clinicDB = clinicDB;
        }

        public bool SaveTechnicalSpec(TecnicalSpec tecnicalSpec)
        {
            return clinicDB.SaveTechnicalSpec(tecnicalSpec);
        }
    }
}
