﻿using System;
using System.Collections.Generic;
using System.Text;
using DLL_Technician;
using CoreEFTest;
using CoreEFTest.Models;

namespace BLL_Technician
{ 

    public class UC6_ShowProcess
    {
        private IClinicDB clinicDB;
        public UC6_ShowProcess(IClinicDB clinicDb)
        {
            clinicDB = clinicDb;
        }

        
    }
}
