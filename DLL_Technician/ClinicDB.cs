using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public class ClinicDB:IClinicDB
    {
        public Patient GetPatient(string CPR)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHA(string CPR)
        {
            //Todo forbindelse til den rigtige database
            throw new NotImplementedException();
        }
    }
}
