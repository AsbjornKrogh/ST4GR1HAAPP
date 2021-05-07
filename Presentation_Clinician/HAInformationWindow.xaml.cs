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
        private Patient _patient;
        private List<GeneralSpec> listGeneralSpecs;
        


        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
        {
            InitializeComponent();
            _clinicianMain = clinicianMainWindow;
            _manageHA = manageHa;
            

        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.CPR);

            foreach (var clinicianSpec in listGeneralSpecs)
            {
                if (clinicianSpec != null)
                {
                    Lb_OldHearingRight.Items.Add("Dato: " + _patient.GeneralSpecs[5].CreateDate);
                }
                else
                {
                    Lb_OldHearingLeft.Items.Add("Dato: " + _patient.GeneralSpecs[4].CreateDate);

                }
               
            }
            
        }

      

        private void btn_ShowOldAid_Click(object sender, RoutedEventArgs e)
        {
            _patient=new Patient();
            listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.CPR);
            GeneralSpec selectedGeneralSpec = (GeneralSpec)_patient.GeneralSpecs[Lb_OldHearingLeft.SelectedIndex];

            

            foreach (var item in listGeneralSpecs)
            {
                if (Lb_OldHearingLeft.SelectedItems.ToString() == "Dato: " + item.CreateDate)
                {
                    Tblock_OldHearingAid.Text = "Øre: " + Convert.ToString(item.EarSide) + "\r\nDato " + Convert.ToString(item.CreateDate) + "\r\nFarve : " + Convert.ToString(item.Color);
                }
            }

            
            

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
