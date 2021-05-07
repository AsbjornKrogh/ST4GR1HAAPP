using System;
using System.Collections.Generic;
using System.Text;
using CoreEFTest.Models;
using DLL_Technician;
using DLL_Technician.Printer;

namespace BLL_Technician
{
    public class UC5_Print
    {
        private IClinicDB db;
        private IPrinter printer;
        public UC5_Print(IClinicDB db, IPrinter printer)
        {
            this.db = db;
            this.printer = printer;
        }

        public List<TecnicalSpec> GetEarScans()
        {
            return db.GetEarScans();
        }

        public List<TecnicalSpec> GetEarScan(string CPR)
        {
            return db.GetTechnicalSpecs(CPR);
        }

        public bool ConnectToPrinter()
        {
            return printer.connectToPrinter();
        }

        public RawEarPrint AddToPrintQueue(int printTechID, List<RawEarScan> earScans)
        {
            return printer.StartPrint(printTechID, earScans);
        }

    }
}
