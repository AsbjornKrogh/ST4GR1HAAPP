using System;
using CoreEFTest.Context;

namespace DLL_Technician
{
   public class ClinicDBFactory
   {
       public IClinicDB CreateNoClinicDb()
       {
           return new ClinicNoDB();
       }

       public IClinicDB CreateClinicDb()
       {
           return new ClinicDB(new ClinicDBContext());
       }
   }
}
