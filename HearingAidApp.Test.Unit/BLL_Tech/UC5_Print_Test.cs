﻿using BLL_Technician;
using DLL_Technician;
using NSubstitute;
using NUnit.Framework;

namespace Techinician_HearingAidApp.Test.Unit
{
    class UC5_Print
    {
        private UC4_Scan uut;
        private IClinicDB _clinicDB;
        private IScanner _scanner;

        [SetUp]
        public void Setup()
        {
            _scanner = Substitute.For<IScanner>();
            _clinicDB = Substitute.For<IClinicDB>();
            uut = new UC4_Scan(_clinicDB, _scanner);

        }

        [Test]
        public void UC4_Scan_ConnectToScanner_ScannerRecievesConnectCall()
        {
            //Act
            uut.ConnectToScanner();

            //Test
            _scanner.Received().connectTo3DScanner();

        }

        [Test]
        public void UC4_Scan_StarttScanner_ScannerRecievesStartCall()
        {
            uut.StartScanning(1);

            _scanner.Received().StartScanning(1);
        }


        [Test]
        public void UC4_Scan_GetPatientInformations_ClinicRecievesGetCall()
        {
            uut.GetPatientInformations("1111111-0000");

            _clinicDB.Received().GetPatientInformations("1111111-0000");
        }
    }
}
}
