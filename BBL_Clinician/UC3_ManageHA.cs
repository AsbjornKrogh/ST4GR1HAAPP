using System;
using System.Collections.Generic;
using CoreEFTest.Models;
using DLL_Clinician;

namespace BBL_Clinician
{
   public class UC3_ManageHA
   {
       private IClinicDatabase clinicDatabase;
       GeneralSpec generalSpec = new GeneralSpec();

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

       public void SaveHA(Ear earSide, Material type, PlugColor color, DateTime createDate, string StaffID)
       {
       }

        public void CreateHA(GeneralSpec generalSpec)
        {
            clinicDatabase.CreateNewGeneralSpec(generalSpec);
        }

        public List<GeneralSpec> GetAllHA(string CPR)
       {
          return clinicDatabase.GetAlleGeneralSpecs(CPR);
       }

   }
}
