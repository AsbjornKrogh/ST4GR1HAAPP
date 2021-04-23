using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace HL7_FHIR
{
   public class HL7FHIRClient
   {
      private FhirClient client;

      public HL7FHIRClient()
      {
         //client = new FhirClient("https://aseecest3fhirservice.azurewebsites.net/");
         client = new FhirClient("https://vonk.fire.ly");
         client.Timeout = 120000;
      }

      public string CreateHl7FHIRPatient(Patient model)
      {
         Patient models = client.Create<Patient>(model);
           
         return models.Id;
      }

      public Patient ReadHl7FHIRPatient(string id)
      {
         var location = new Uri("https://aseecest3fhirservice.azurewebsites.net/Patient/" + id);
         var patient = client.Read<Patient>(location);

         return patient;
      }

      public Patient FindPatientByCPR(string CPR)
      {
         Bundle result = client.Search<Patient>(null);

         foreach (Bundle.EntryComponent component in result.Entry)
         {
            Patient patient = (Patient) component.Resource;

            Console.WriteLine(patient.Name[0].ToString());
         }
      
         return new Patient();
      }

   }
}
