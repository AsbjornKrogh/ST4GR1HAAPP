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

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        private UC2_ManagePatient uc2ManagePatient;
        private Patient patient;

        private MainWindow mainWindow;
     

        public PatientPage(MainWindow mainWindow, UC2_ManagePatient managePatient)
        {
            InitializeComponent();

            //uc2ManagePatient = new UC2_ManagePatient();
            //mainWindow = new MainWindow();
            this.mainWindow = mainWindow;
            this.uc2ManagePatient = managePatient;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            uc2ManagePatient.SavePatientPressed(patient,TBemail.Text, Convert.ToInt16(TBphonenumber.Text));
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            TBphonenumber.Focus();
        }

        private void PatientPage1_Loaded(object sender, RoutedEventArgs e)
        {
            TBname.Text = "TestNavn";
            TBsurname.Text = "TestEfternavn";
            TBCPR.Text = "123456-7890";
            TBAddress.Text = "Testvej 2";
            patient = uc2ManagePatient.GetPatientInformation(mainWindow.CPR);

            //TBname.Text = patient.Name;
            //TBsurname.Text = patient.Lastname;
            //TBCPR.Text = patient.CPR;
            //TBAddress.Text = patient.Adress;
        }
    }
}
