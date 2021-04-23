using System;
using System.Collections.Generic;
using System.Text;
using BLL_Technician;
using DLL_Technician;
using NSubstitute;
using NUnit.Framework;

namespace Technician_HearingAidApp.Test.Unit
{
    public class UC5_Print_Test
    {
        private UC5_Print uut;
        private IClinicDB _clinicDB;


        [SetUp]
        public void Setup()
        {
            _clinicDB = Substitute.For<IClinicDB>();
            //uut = new UC5_Scan();

        }

        [Test]
        public void UC5()
        {


        }
    }

}
