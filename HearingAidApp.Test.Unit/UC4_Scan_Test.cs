using BLL_Technician;
using DLL_Technician;
using NSubstitute;
using NUnit.Framework;

namespace HearingAidApp.Test.Unit
{
    public class UC4_Scan_Test
    {
        private UC4_Scan uut;
        private IClinicDB _clinicDB;
        private IScanner _scanner;

        [SetUp] 
        public void Setup()
        {
            _scanner = Substitute.For<IScanner>();
            _clinicDB = Substitute.For<IClinicDB>();
            uut = new UC4_Scan(_clinicDB,_scanner);

        }

        [Test]
        public void Test1()
        {
            uut.ConnectToScanner();

            _scanner.Received().connectTo3DScanner();

        }
    }
}