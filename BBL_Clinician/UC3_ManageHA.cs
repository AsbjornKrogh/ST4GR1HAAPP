using System;
using System.Collections.Generic;
using CoreEFTest.Models;
using DLL_Clinician;

namespace BLL_Clinician
{
   public class UC3_ManageHA
   {
       private IClinicDatabase clinicDatabase;
       
       public UC3_ManageHA(IClinicDatabase _clinicDatabase)
       {
           clinicDatabase = _clinicDatabase;
       }

       public List<GeneralSpec> GetHA(string CPR)
       {
           return clinicDatabase.GetLatestGeneralSpecs(CPR);
       }

        public void CreateHA(GeneralSpec generalSpec)
        {
            clinicDatabase.CreateNewGeneralSpec(generalSpec);
        }

        public List<GeneralSpec> GetAllHA(string CPR)
       {
          return clinicDatabase.GetAllGeneralSpecs(CPR);
       }

        public void CreateEC(EarCast earCast)
        {
          clinicDatabase.CreateEarCast(earCast);
        }
   }
}
