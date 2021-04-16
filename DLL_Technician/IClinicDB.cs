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
    }
}
