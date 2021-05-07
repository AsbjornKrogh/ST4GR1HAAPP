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

       public bool SaveHA(int HearingAidID, string type, string color, DateTime createDate, int ClinianID)
       {
            
           return true;
           //måske skal vi benytte general spec her - ved ikke om man skal have en datetime og staffid med her
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
