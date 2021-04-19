using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CoreEFTest.Models;

namespace DLL_Technician
{
    public class NoScanner:IScanner
    {
        private Random random = new Random();
        private RawEarScan earscan;
        private ITimeStamp timeStamp;

        public NoScanner(ITimeStamp timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public bool connectTo3DScanner()
        {
            int trigger = random.Next(1, 10);

            if (trigger > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public RawEarScan StartScanning(int ScanTechID)
        {
            earscan = new RawEarScan();

            earscan.StaffID = ScanTechID;
            earscan.ScanDate = timeStamp.getDate();

            Thread.Sleep(3000);

            return earscan;
        }
    }
}
