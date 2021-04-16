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
        private IClinicDatabase clinicDatabase;

        private Patient patient;
        

        public PatientPage()
        {
            InitializeComponent();
            uc2ManagePatient= new UC2_ManagePatient();
            

        }

        public void PatientPage_Load(object source, EventArgs e)
        {
            
            TBname.Text = patient.Name;
            TBsurname.Text = patient.Lastname;
            TBCPR.Text = patient.CPR;
            TBAddress.Text = patient.Adress;

        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            uc2ManagePatient.SaveUpdates(TBemail.Text, Convert.ToInt16(TBphonenumber.Text));

        }

        private void bntUpdate_Click(object sender, RoutedEventArgs e)
        {
            TBphonenumber.Focus();
        }
    }
}