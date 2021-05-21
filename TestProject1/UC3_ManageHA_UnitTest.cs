using System;
using System.Collections.Generic;
using System.Text;
using BLL_Clinician;
using BLL_Technician;
using DLL_Clinician;
using DLL_Technician;
using NSubstitute;
using NUnit.Framework;

namespace Clinician_HearingAidApp.Test.Unit
{
   public class UC3_ManageHA_UnitTest
   {
       private UC3_ManageHA uut;
       private IClinicDatabase db;

        [SetUp]
        public void Setup()
        {
            uut = new UC3_ManageHA();
            db = Substitute.For<IClinicDatabase>();

        }

        //[Test]
        //public void CreateHA_ExpectedResult_CallCreateNewGeneralSpec()
        //{
        //    uut.CreateHA();
        //}

        [Test]
        public void GetAllHA_ExpectedResult_CallCreateNewGeneralSpec()
        {
            uut.GetAllHA("1234");

            db.Received(1).GetAllGeneralSpecs("1234");
        }

    }
}
