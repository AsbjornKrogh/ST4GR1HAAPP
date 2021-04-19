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
using BLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private UC2_ManagePatient uc2ManagePatient;
        //private PatientPage patientPage;

        public HomePage()
        {
            InitializeComponent();
            uc2ManagePatient = new UC2_ManagePatient();
            //patientPage = new PatientPage();

            tbCPR.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string cpr = tbCPR.Text;
            
            MessageBox.Show("Hej");

            //if (uc2ManagePatient.FindCPR(cpr))
            //{
            //    mainWindow.OpenPatientPage();
            //    MessageBox.Show("true");
            //}
            //else
            //{
            //    MessageBox.Show("Ugyldigt CPR");
            //}

        }
    }
}

