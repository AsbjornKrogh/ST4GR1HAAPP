﻿using System;
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
        

        private HomeWindow homeWindow;
     

        public PatientPage()
        {
            InitializeComponent();
            uc2ManagePatient= new UC2_ManagePatient();
            homeWindow = new HomeWindow();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            uc2ManagePatient.SavePatientPressed(patient,TBemail.Text, Convert.ToInt16(TBphonenumber.Text));
            MessageBox.Show("Patienten er gemt");
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            TBemail.IsEnabled = true;
            TBphonenumber.IsEnabled = true;
            TBphonenumber.Focus();
        }

        private void PatientPage1_Loaded(object sender, RoutedEventArgs e)
        {
            patient = uc2ManagePatient.GetPatientInformation(homeWindow.TbCPRnumber.Text);

            TBname.Text = patient.Name;
            TBsurname.Text = patient.Lastname;
            TBCPR.Text = patient.CPR;
            TBAddress.Text = patient.Adress;

            TBname.IsEnabled = false;
            TBsurname.IsEnabled = false;
            TBCPR.IsEnabled = false;
            TBAddress.IsEnabled = false;
            TBemail.IsEnabled = false;
            TBphonenumber.IsEnabled = false;
        }
    }
}
