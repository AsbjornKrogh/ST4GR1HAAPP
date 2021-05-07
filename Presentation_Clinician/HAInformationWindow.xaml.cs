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
using System.Windows.Shapes;
using BBL_Clinician;
using CoreEFTest.Models;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HAInformationWindow.xaml
    /// </summary>
    public partial class HAInformationWindow : Window
    {
        UC3_ManageHA _manageHA = new UC3_ManageHA();
        GeneralSpec _generalSpec = new GeneralSpec();
        ClinicianMainWindow _clinicianMain = new ClinicianMainWindow();
        //private List<GeneralSpec> listGeneralSpecs;


        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
        {
            InitializeComponent();
            _clinicianMain = clinicianMainWindow;
            _manageHA = manageHa;

        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            var listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.CPR);

            foreach (var clinicianSpec in listGeneralSpecs)
            {
                if (clinicianSpec.EarSide == Ear.Right)
                {
                    Lb_OldHearingRight.Items.Add("Dato: " + clinicianSpec.CreateDate);
                }
                else if(clinicianSpec.EarSide == Ear.Left)
                {
                    Lb_OldHearingLeft.Items.Add("Dato: " + clinicianSpec.CreateDate);
                }
                else if (listGeneralSpecs != null)
                {
                    Lb_OldHearingLeft.Items.Add("Patienten har ingen tidligere høreapparter for venstre øre");
                    Lb_OldHearingRight.Items.Add("Patienten har ingen tidligere høreapparter for venstre øre");
                }
            }
            
        }

        private void Tblock_OldHearingAid_Loaded(object sender, RoutedEventArgs e)
        {

            Tblock_OldHearingAid.Text = _generalSpec.CPR;
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.CreateDate);
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.EarSide);
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.Color);
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.Type);
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.HAGeneralSpecID);
            Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.StaffID);
        }

        private void Lb_OldHearingRight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
