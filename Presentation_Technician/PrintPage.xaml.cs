using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL_Technician;
using DLL_Technician;
using CoreEFTest.Models;
using DLL_Technician.Printer;

namespace Presentation_Technician
{
    /// <summary>
    /// Interaction logic for PrintPage.xaml
    /// </summary>
    public partial class PrintPage : Page
    {
        private bool isRunning;
        private IClinicDB db;
        private IPrinter printer;
        private StaffLogin technician;
        private UC5_Print uc5_print;
        private bool HentisRunning;
        private bool ScanisRunning;
        private List<TecnicalSpec> patientInformationsAll;
        private RawEarScan rawEarScan;


        public PrintPage(IClinicDB db, IPrinter printer, StaffLogin technician)
        {
            InitializeComponent();
            this.db = db;
            this.printer = printer;
            this.technician = technician;

            uc5_print = new UC5_Print(db, printer);
            PrintB.IsEnabled = false;

        }

        #region Hent

        #region Find alle høreapparater

        private void FindAllPatientsB_Click(object sender, RoutedEventArgs e)
        {
            FindScanB.IsEnabled = false;
            if (isRunning != true)
            {
                    isRunning = true;

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += UC4GetPatientInformationAll;
                    worker.RunWorkerCompleted += UC4GetPatientInformationAllCompleted;

                    worker.RunWorkerAsync();

                    Loading.Visibility = Visibility.Visible;
                    Loading.Spin = true;

                    //Thread.Sleep(1500);
                    //MessageBox.Show("Der blev ikke fundet nogle høreapparater, der er klar til print")
            }
        }


        public void UC4GetPatientInformationAll(object sender, DoWorkEventArgs e)
        {
            e.Result = uc5_print.GetEarScans();
        }

        public void UC4GetPatientInformationAllCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HentisRunning = false;
            Loading.Spin = false;
            Loading.Visibility = Visibility.Collapsed;

            FindAllPatientsB.Visibility = Visibility.Visible;

            patientInformationsAll = (List<TecnicalSpec>)e.Result;

            foreach (var tecnicalSpec in patientInformationsAll)
            {
                if (tecnicalSpec != null)
                {
                    PatientInformationLB.Items.Add("CPR: " + tecnicalSpec.CPR + /*"\r\nNavn: " + tecnicalSpec.Patient.Name + " " + tecnicalSpec.Patient.Lastname +*/ "\r\nØre: " + tecnicalSpec.EarSide);
                }
                else
                {
                    PatientInformationLB.Items.Add("Der er ingen ørepropper klar til print");
                }
            }
            PrintB.IsEnabled = true;
        }
        #endregion

        #region Find en patient

        
        private void FindScanB_Click(object sender, RoutedEventArgs e)
        {
            if (CPRnummerTB.Text == "")
            {
                MessageBox.Show("Indtast et CPR-nummer","Fejl");
            }
            else
            {
                FindAllPatientsB.IsEnabled = false;
                if (isRunning != true) 
                {
                 isRunning = true;

                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += UC5GetPatientInformation;
                worker.RunWorkerCompleted += UC5GetPatientInformationCompleted;

                string CPR = CPRnummerTB.Text;
                worker.RunWorkerAsync(CPR);

                Loading.Visibility = Visibility.Visible;
                Loading.Spin = true;

                //Thread.Sleep(1500);
                //MessageBox.Show("Der blev ikke fundet nogle høreapparater, der er klar til print")
                }
            }
        }

        public void UC5GetPatientInformation(object sender, DoWorkEventArgs e)
        {
            e.Result = uc5_print.GetEarScan((string)e.Argument);
        }

        public void UC5GetPatientInformationCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HentisRunning = false;
            Loading.Spin = false;
            Loading.Visibility = Visibility.Collapsed;

            FindAllPatientsB.Visibility = Visibility.Visible;

            patientInformationsAll = (List<TecnicalSpec>)e.Result;

            int count = 0;

            foreach (var tecnicalSpec in patientInformationsAll)
            {
                if (tecnicalSpec != null)
                {
                    if (count == 0)
                    {
                        PatientInformationTB.Text = "CPR: " + tecnicalSpec.CPR + /*"\r\nNavn: " + tecnicalSpec.Patient.Name + " " + tecnicalSpec.Patient.Lastname +*/ "\r\nØre: " + tecnicalSpec.EarSide;
                        count++;
                    }
                    else
                    {
                        PatientInformationTB.Text += "\r\nØre: " + tecnicalSpec.EarSide;

                    }
                }
                else
                {
                    PatientInformationTB.Text = "Der er ingen ørepropper klar til print";
                }
            }
            PrintB.IsEnabled = true;
        }

        #endregion
        #endregion
    }
}
