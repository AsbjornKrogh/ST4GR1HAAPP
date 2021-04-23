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

        private MainWindow mainWindow;
     

        public PatientPage(MainWindow mainWindow, UC2_ManagePatient managePatient)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.uc2ManagePatient = managePatient;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //uc2ManagePatient.SavePatientPressed(patient,TBemail.Text, Convert.ToInt16(TBphonenumber.Text));
            TBphonenumber.Text = patient.Email;
            TBemail.Text = patient.MobilNummer;
            uc2ManagePatient.SavePatientPressed(patient);
            MessageBox.Show("Patienten er gemt");
        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            TBemail.IsEnabled = true;
            TBphonenumber.IsEnabled = true;
            TBemail.Focus();
        }

        private void PatientPage1_Loaded(object sender, RoutedEventArgs e)
        {
            patient = uc2ManagePatient.GetPatientInformation(mainWindow.CPR);
            TBname.Text = patient.Name;
            TBsurname.Text = patient.Lastname;
            TBCPR.Text = patient.CPR;
            TBAddress.Text = patient.Adress;
            TbCity.Text = patient.City;
            TbZipcode.Text = Convert.ToString(patient.zipcode);
            TBphonenumber.Text = patient.MobilNummer;
            TBemail.Text = patient.Email;


            TBname.IsEnabled = false;
            TBsurname.IsEnabled = false;
            TBCPR.IsEnabled = false;
            TBAddress.IsEnabled = false;
            TbCity.IsEnabled = false;
            TbZipcode.IsEnabled = false;
            TBemail.IsEnabled = false;
            TBphonenumber.IsEnabled = false;
        }
    }
}
