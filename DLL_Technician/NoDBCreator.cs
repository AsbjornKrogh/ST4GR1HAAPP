using System;
using System.Collections.Generic;
using System.Text;

namespace DLL_Technician
{
    public class NoDBCreator
    {
        public IClinicDB CreateNewDB()
        {
            return new ClinicNoDB();
        }
    }
}
