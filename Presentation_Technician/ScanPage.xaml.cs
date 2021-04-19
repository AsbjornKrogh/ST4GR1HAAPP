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
        private UC4_Scan uc4_scan;
        private bool HentisRunning;
        private bool ScanisRunning;
        private Patient patientAndHA;

        private const string MODEL_PATH = "Fingerklemme 1.1.stl";

        public ScanPage(IClinicDB db, IScanner scanner)
        {
            InitializeComponent();
            this.db = db;
            this.scanner = scanner;

            uc4_scan = new UC4_Scan(db, scanner);

            var modelImport = new ModelImporter();
            //Model3D currentModel  = modelImport.Load(MODEL_PATH);
            
            Visual3D.Content = modelImport.Load(MODEL_PATH);

            //EarScan.Children.Add(new ModelVisual3D { Content = currentModel });
            //EarScan.IsZoomEnabled = true;
        }

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

                    worker.RunWorkerAsync();

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
            //e.Result =
        }

        public void UC4ScanCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ScanLoading.Visibility = Visibility.Collapsed;
            ScanLoading.Spin = false;
            ScannerL.Visibility = Visibility.Collapsed;
        }

        private void GemB_Click(object sender, RoutedEventArgs e)
        {
            //Kald til DB om at gemme...
        }
    }
}
