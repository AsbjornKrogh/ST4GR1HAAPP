using System;
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

       public void GetHearingTest(string CPRnummer)
       {

       }

       public void GetHA(string CPRnummer)
       {
            
       }

       public bool SaveHA(int HearingAidID, string type, string color, DateTime createDate, int ClinianID)
       {
           return true;
           //måske skal vi benytte general spec her - ved ikke om man skal have en datetime og staffid med her
       }

       public void GetAllHA(){}

   }
}
