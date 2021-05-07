using System;
using System.Collections.Generic;
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
using BBL_Clinician;
using BLL_Clinician;
using CoreEFTest.Models;
using DLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        private UC2_ManagePatient uc2ManagePatient;
        private Patient patient;

        private ClinicianMainWindow _clinicianMainWindow;
     

        public PatientPage(ClinicianMainWindow clinicianMainWindow, UC2_ManagePatient managePatient)
        {
            InitializeComponent();

            this._clinicianMainWindow = clinicianMainWindow;
            this.uc2ManagePatient = managePatient;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TBCPR.Text == patient.CPR)
            {
                patient.Email = TBEmail.Text;
                patient.MobilNummer = TBPhonenumber.Text;
                uc2ManagePatient.SaveUpdates(patient);
                MessageBox.Show("Patientens e-mail og telefonnummer er opdateret");
            }
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            TBEmail.IsEnabled = true;
            TBPhonenumber.IsEnabled = true;
            TBPhonenumber.Focus();
        }

        private void PatientPage1_Loaded(object sender, RoutedEventArgs e)
        {
            patient = uc2ManagePatient.GetPatientInformation(_clinicianMainWindow.CPR);
            TBname.Text = patient.Name;
            TBsurname.Text = patient.Lastname;
            TBCPR.Text = patient.CPR;
            TBAddress.Text = patient.Adress;
            TbCity.Text = patient.City;
            TbZipcode.Text = Convert.ToString(patient.zipcode);
            TBPhonenumber.Text = patient.MobilNummer;
            TBEmail.Text = patient.Email;
            
            TBname.IsEnabled = false;
            TBsurname.IsEnabled = false;
            TBCPR.IsEnabled = false;
            TBAddress.IsEnabled = false;
            TbCity.IsEnabled = false;
            TbZipcode.IsEnabled = false;
            TBEmail.IsEnabled = false;
            TBPhonenumber.IsEnabled = false;
        }
    }
}
