using System;
using CoreEFTest.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using DLL_Clinician.RegionsDatabase;
using Hl7.Fhir.Serialization;

namespace DLL_Clinician
{
   public class RegionDatabase : IRegionDatabase
   {
      private FhirClient client;

      public RegionDatabase()
      {
         client = new FhirClient("https://aseecest3fhirservice.azurewebsites.net/");
         client.Timeout = 120000;
      }

      public bool CheckCPR(string CPR)
      {
         return true;
      }

      /// <summary>
      /// Metoden finder en patient i HL7-Fhir databasen med det givne CPR og returnere et patient objekt. 
      /// </summary>
      /// <param name="CPR"></param>
      /// <returns></returns>
      public CoreEFTest.Models.Patient GetPatient(string CPR)
      {
         CoreEFTest.Models.Patient patient = new CoreEFTest.Models.Patient();

         var con = new SearchParams();

         con.Add("identifier", CPR);

         Bundle result = client.Search<Hl7.Fhir.Model.Patient>(con);

         foreach (Bundle.EntryComponent component in result.Entry)
         {
            Hl7.Fhir.Model.Patient Hl7patient = (Hl7.Fhir.Model.Patient)component.Resource;


            patient.Lastname = Hl7patient.Name[0].Family;
            Date date = Hl7patient.BirthDateElement;
            //patient.Age = date.
            patient.Adress = Hl7patient.Address[0].District;
            patient.City = Hl7patient.Address[0].City;
            patient.zipcode = Convert.ToInt32(Hl7patient.Address[0].PostalCode);
            break;
         }

         return patient;
      }
   }
}
