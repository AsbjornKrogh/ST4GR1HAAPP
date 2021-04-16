using System;
using System.Collections.Generic;
using System.Text;

namespace DLL_Technician
{
    public class NoScanner:IScanner
    {
        private Random random = new Random();
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
    }
}
