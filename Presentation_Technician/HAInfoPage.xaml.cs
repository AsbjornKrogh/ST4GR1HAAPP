using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for HAInfoPage.xaml
    /// </summary>
    public partial class HAInfoPage : Page
    {
        private UC3_ShowHATech uc3_ShowHATech;

        private IClinicDB db;
        private bool isRunning;
        private Patient patientAndHA;

        public HAInfoPage(IClinicDB db)
        {
            InitializeComponent();
            this.db = db;
            uc3_ShowHATech = new UC3_ShowHATech(db);
        }

        private void OKB_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning != true)
            {
                string CPR = CPRnummerTB.Text;
                if (CPR.Length == 11 && CPR.Contains('-'))
                {
                    isRunning = true;

                    BackgroundWorker worker = new BackgroundWorker();


                    worker.DoWork += UC3GetPatient;

                    worker.RunWorkerCompleted += UC3GetPatientCompleted;

                    worker.RunWorkerAsync(CPR);

                    Loading.Visibility = Visibility.Visible;
                    Loading.Spin = true;
                }
                else
                {
                    MessageBox.Show("Indtast gyldigt CPR");

                }
            }
        }

        public void UC3GetPatient(object sender, DoWorkEventArgs e)
        {
            string CPR = (string) e.Argument;
            e.Result = uc3_ShowHATech.GetPatient(CPR);
        }

        public void UC3GetPatientCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isRunning = false;
            Loading.Spin = false;
            Loading.Visibility = Visibility.Collapsed;

            patientAndHA = (Patient) e.Result;

            if (patientAndHA != null)
            {
                patientInfoTB.Text = "CPR: " + patientAndHA.CPR + "\r\nNavn: " + patientAndHA.Name + " " + patientAndHA.Lastname + "\r\nAlder: " + patientAndHA.Age;
                HAList.Items.Add(patientAndHA.EarCasts[0].EarSide.ToString());
                HAList.Items.Add(patientAndHA.EarCasts[1].EarSide.ToString());
            }
            else
            {
                patientInfoTB.Text = "Det indtastede CPR nummer findes ikke i databasen";
            }

        }

        private void ShowHAInfoB_Click(object sender, RoutedEventArgs e)
        {
            EarCast selected = (EarCast)patientAndHA.EarCasts[HAList.SelectedIndex];

            TypeTB.Text = selected.PatientCPR;


        }
    }
}
