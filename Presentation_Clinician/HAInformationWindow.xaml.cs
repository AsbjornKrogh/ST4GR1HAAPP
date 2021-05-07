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
using System.Windows.Shapes;
using BLL_Clinician;
using CoreEFTest.Models;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HAInformationWindow.xaml
    /// </summary>
    public partial class HAInformationWindow : Window
    {
        UC3_ManageHA _manageHA = new UC3_ManageHA();

        ClinicianMainWindow _clinicianMainWindow = new ClinicianMainWindow();

        GeneralSpec _generalSpec = new GeneralSpec();
        private Patient _patient;
        private List<GeneralSpec> listGeneralSpecs;
        private ManageHAPage manageHa;

        

        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
        {
            InitializeComponent();
            _clinicianMainWindow = clinicianMainWindow;
            _manageHA = manageHa;
        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            listGeneralSpecs = _manageHA.GetAllHA(_clinicianMainWindow.Patient.CPR);
      

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
               
            }
            
        }



        private void btn_ShowOldAid_Click(object sender, RoutedEventArgs e)
        {

            //    //listGeneralSpecs = _manageHA.GetAllHA(_clinicianMainWindow.Patient.CPR);
            //    //_generalSpec = (GeneralSpec)_patient.GeneralSpecs[Lb_OldHearingLeft.SelectedIndex];
            //    _generalSpec = _clinicianMainWindow.Patient.GeneralSpecs[Lb_OldHearingLeft.SelectedIndex];

            //    foreach (var item in listGeneralSpecs)
            //    {
            //        if (Lb_OldHearingLeft.SelectedItems.ToString() == "Dato: " + item.CreateDate)
            //        {
            //            Tblock_OldHearingAid.Text = "Øre: " + Convert.ToString(item.EarSide) + "\r\nDato " + Convert.ToString(item.CreateDate) + "\r\nFarve : " + Convert.ToString(item.Color);
            //        }
            //    }




            //Tblock_OldHearingAid.Text = selectedGeneralSpec.CPR;
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.EarSide);
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.CreateDate);
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.Color);
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.Type);
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.HAGeneralSpecID);
            //Tblock_OldHearingAid.Text = Convert.ToString(selectedGeneralSpec.StaffID);




            //Tblock_OldHearingAid.Text =  "Øre: " + Convert.ToString(_generalSpec.EarSide) + "\r\nDato " + Convert.ToString(_generalSpec.CreateDate) + "\r\nFarve : " + Convert.ToString(_generalSpec.Color);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.EarSide);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.CreateDate);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.Color);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.Type);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.HAGeneralSpecID);
            //Tblock_OldHearingAid.Text = Convert.ToString(_generalSpec.StaffID);



        }

    }
}

