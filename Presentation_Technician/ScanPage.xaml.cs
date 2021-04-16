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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL_Technician;
using CoreEFTest.Models;
using DLL_Technician;

namespace Presentation_Technician
{
    /// <summary>
    /// Interaction logic for ScanPage.xaml
    /// </summary>
    public partial class ScanPage : Page
    {
        private IClinicDB db;
        private UC4_Scan uc4_scan;
        private bool HentisRunning;
        private bool ScanisRunning;
        private Patient patientAndHA;
        public ScanPage(IClinicDB db)
        {
            InitializeComponent();
            this.db = db;
            uc4_scan = new UC4_Scan(db);
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
                    //ScanisRunning = true;

                    //BackgroundWorker worker = new BackgroundWorker();

                    //worker.DoWork += ;

                    //worker.RunWorkerCompleted += ;

                    //string castID = HACastIDTB.Text;
                    //worker.RunWorkerAsync();

                    //Loading.Visibility = Visibility.Visible;
                    //Loading.Spin = true;
                }
            }
            else
            {
                MessageBox.Show("Der kan ikke oprettes forbindelse til scanneren - prøv igen...","Advarelse", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
    }
}
