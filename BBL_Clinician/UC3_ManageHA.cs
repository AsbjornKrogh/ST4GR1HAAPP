using System;
using System.Collections.Generic;
using CoreEFTest.Models;
using DLL_Clinician;

namespace BLL_Clinician
{
   public class UC3_ManageHA
   {
       private IClinicDatabase clinicDatabase;
       
       public UC3_ManageHA()
       {
           clinicDatabase = new ClinicDatabase();
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

        public void createEC(EarCast earCast)
        {
          clinicDatabase.CreateEarCast(earCast);
        }
   }
}
