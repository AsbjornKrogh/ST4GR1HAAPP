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
using DLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for PatientPage.xaml
    /// </summary>
    public partial class PatientPage : Page
    {
        private UC2_ManagePatient uc2ManagePatient;
        private IClinicDatabase clinicDatabase;

        public PatientPage(IClinicDatabase clinicDatabase)
        {
            InitializeComponent();
            this.clinicDatabase = clinicDatabase;
            uc2ManagePatient= new UC2_ManagePatient(clinicDatabase);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            uc2ManagePatient.SaveUpdates(TBemail.SelectedText, Convert.ToInt16(TBphonenumber.SelectedText));

        }

    }
}
