using System;
using System.Collections.Generic;
using System.Text;

namespace DLL_Technician
{
    public class ClinicDBCreator
    {
        public IClinicDB CreateNewDB()
        {
            return new ClinicDB();
        }
    }
}
