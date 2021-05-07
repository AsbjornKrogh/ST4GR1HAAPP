using System;
using System.Collections.Generic;
using CoreEFTest.Models;
using DLL_Clinician;

namespace BBL_Clinician
{
   public class UC3_ManageHA
   {
       private IClinicDatabase clinicDatabase;

       public UC3_ManageHA()
       {
           clinicDatabase = new ClinicDatabase();
       }

       public void GetHearingTest(string CPR)
       {

       }

       public List<GeneralSpec> GetHA(string CPR)
       {
           return clinicDatabase.GetLatestGeneralSpecs(CPR);

       }

       public void SaveHA(int HearingAidID, string type, string color, DateTime createDate, int ClinianID)
       {
           GeneralSpec generalSpec = new GeneralSpec();
           clinicDatabase.CreateNewGeneralSpec(generalSpec);
            
       }

        public void CreateHA(GeneralSpec generalSpec)
        {
            
        }

        public List<GeneralSpec> GetAllHA(string CPR)
       {
          return clinicDatabase.GetAlleGeneralSpecs(CPR);
       }

   }
}
