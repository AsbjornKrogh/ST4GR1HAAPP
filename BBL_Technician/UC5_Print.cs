using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Technician;

namespace BLL_Technician
{
    public class UC5_Print
    {
        private IClinicDB db;
        public UC5_Print(IClinicDB db)
        {
            this.db = db;
        }

    }
}
