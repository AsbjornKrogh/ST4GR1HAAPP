using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL_Technician;
using CoreEFTest.Models;
using DLL_Technician;
using HelixToolkit.Wpf;

namespace Presentation_Technician
{
    /// <summary>
    /// Interaction logic for ScanPage.xaml
    /// </summary>
    public partial class ScanPage : Page
    {
        private IClinicDB db;
        private IScanner scanner;
        private StaffLogin technician;
        private UC4_Scan uc4_scan;
        private bool HentisRunning;
        private bool ScanisRunning;
        private Patient patientAndHA;
        private RawEarScan rawEarScan;
        private ModelImporter modelImporter;

        private const string MODEL_PATH = "Fingerklemme 1.1.stl";

        public ScanPage(IClinicDB db, IScanner scanner, StaffLogin technician)
        {
            InitializeComponent();
            this.db = db;
            this.scanner = scanner;
            this.technician = technician;

            uc4_scan = new UC4_Scan(db, scanner);

            modelImporter = new ModelImporter();
            
        }

        #region Hent metoder
        private void HentInfoB_Click(object sender, RoutedEventArgs e)
        {
            if (HentisRunning != true)
            {
                HentisRunning = true;

                BackgroundWorker worker = new BackgroundWorker();

                worker.DoWork += UC4GetPatientInformation;

                worker.RunWorkerCompleted += UC4GetPatientInformationCompleted;

                string castID = HACastIDTB.Text;
                worker.RunWorkerAsync(castID);

                Loading.Visibility = Visibility.Visible;
                Loading.Spin = true;
            }
            
        }

        public void UC4GetPatientInformation(object sender, DoWorkEventArgs e)
        {
            e.Result = uc4_scan.GetPatientInformations((string)e.Argument);
        }

        public void UC4GetPatientInformationCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HentisRunning = false;
            Loading.Spin = false;
            Loading.Visibility = Visibility.Collapsed;

            PatientInformationTB.Visibility = Visibility.Visible;

            patientAndHA = (Patient) e.Result;

            if (patientAndHA != null)
            {
                PatientInformationTB.Text = "CPR: " + patientAndHA.CPR + "\r\nNavn: " + patientAndHA.Name + " " + patientAndHA.Lastname + "\r\nAlder: " + patientAndHA.Age;
                ScanB.IsEnabled = true;
            }
            else
            {
                PatientInformationTB.Text = "Det indtastede høreafstøbningsID findes ikke i databasen";
            }
        }
        #endregion

        #region Scan metoder
        private void ScanB_Click(object sender, RoutedEventArgs e)
        {
            bool connection = uc4_scan.ConnectToScanner();

            if (connection == true)
            {
                if (ScanisRunning != true)
                {
                    //Todo tilføj kald til UC4_scan via backgroundworkers
                    ScanisRunning = true;

                    BackgroundWorker worker = new BackgroundWorker();

                    worker.DoWork += UC4StartScan;

                    worker.RunWorkerCompleted += UC4ScanCompleted;

                    worker.RunWorkerAsync(technician.StaffID);

                    ScanLoading.Visibility = Visibility.Visible;
                    ScanLoading.Spin = true;
                    ScannerL.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Der kan ikke oprettes forbindelse til scanneren - prøv igen...","Advarelse", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void UC4StartScan(object sender, DoWorkEventArgs e)
        {
            e.Result = uc4_scan.StartScanning((int) e.Argument);
        }

        public void UC4ScanCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ScanLoading.Visibility = Visibility.Collapsed;
            ScanLoading.Spin = false;
            ScannerL.Visibility = Visibility.Collapsed;

            rawEarScan = (RawEarScan)e.Result;

            //Todo er det sådan vi vil have vist filen?
            //Viser STL-filen på GUI'en
            Visual3D.Content = modelImporter.Load(MODEL_PATH);
            GemB.IsEnabled = false;
        }

        #endregion

        #region Gem metoder
        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            //Kald til DB om at gemme...
        }
        #endregion

    }
}
