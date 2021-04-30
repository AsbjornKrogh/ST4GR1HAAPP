using Hl7.Fhir.Model;
using HL7_FHIR;
using System;

namespace EFCoreTestConsoleApp
{
   public class ProgramHL7
   {
      #region HL7Fhir
      HL7FHIRClient client = new HL7FHIRClient();

      Hl7.Fhir.Model.Patient newHL7Patient = new Hl7.Fhir.Model.Patient();

      public void metode()
      {
         //Navn givning
         var name = new Hl7.Fhir.Model.HumanName();
         name.Use = Hl7.Fhir.Model.HumanName.NameUse.Official;
         name.Prefix = new string[] { "Miss" };
         name.Given = new string[] { "Freja" };
         name.Family = "Fhirman";

         newHL7Patient.Name.Add(name);

         //CPR
         Identifier id = new Identifier();
         id.Value = "123456-0000";

         newHL7Patient.Identifier.Add(id);

         //Adresse
         Address address = new Address();
         address.City = "Aarhus";
         address.Country = "DK";
         address.PostalCode = "8000";
         address.District = "Aarhusvej 15";

         newHL7Patient.Address.Add(address);

         //Age & BD
         Date BD = new Date(2000, 02, 20);

         newHL7Patient.BirthDateElement = BD;

         client.CreateHl7FHIRPatient(newHL7Patient);

         Hl7.Fhir.Model.Patient patient = client.FindPatientByCPR("123456-0000");


         //client.FindPatientByCPR("250997-0000");

         //client.ReadHl7FHIRPatientByName("Name");

         //client.FindPatientByCPRTry("250997-0000");

         //var linst = client.GetObservationsByName("250997-0000");

         //var lins = linst.GetEnumerator().Current.Name[0].Given.ToString();


         //var l = client.GetPatientsByName("Asbjørn", "Krogh");
      }


      #endregion
   }
}