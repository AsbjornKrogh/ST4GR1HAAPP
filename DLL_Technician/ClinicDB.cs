﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreEFTest.Context;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public class ClinicDB : IClinicDB
    {
       private readonly ClinicDBContext _dbContext;

       public ClinicDB(ClinicDBContext dbContext)
       {
          _dbContext = dbContext;
       }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public Patient GetPatient(string CPR)
        {
           Patient patient = _dbContext.Patient.Single(x => x.CPR == CPR);

           return patient;
        }

      public bool DeleteHA(string CPR)
        {
            //Todo forbindelse til den rigtige database
            throw new NotImplementedException();
        }
    }
}
