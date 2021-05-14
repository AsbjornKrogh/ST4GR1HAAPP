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
        ClinicianMainWindow _clinicianMain = new ClinicianMainWindow();
        private Patient _patient = new Patient();
        private GeneralSpec generalSpec;
        private List<GeneralSpec> listGeneralSpecs;
        private UC2_ManagePatient _managePatient;
        


        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow)
        {
            InitializeComponent();
            _clinicianMain = clinicianMainWindow;
            _manageHA = new UC3_ManageHA();
            _managePatient = new UC2_ManagePatient();

        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.Patient.CPR);

            foreach (var clinicianSpec in listGeneralSpecs)
            {
                if (clinicianSpec.EarSide == Ear.Right)
                {
                    Lb_OldHearingRight.Items.Add("Dato " + clinicianSpec.CreateDate);

                }
                else if (clinicianSpec.EarSide == Ear.Left)
                {
                    Lb_OldHearingLeft.Items.Add("Dato: " + clinicianSpec.CreateDate);
                }
            }
        }
        

        private void btn_ShowOldAid_Click(object sender, RoutedEventArgs e)
        {

            // _patient = _managePatient.GetPatientInformation(_clinicianMain.Patient.CPR);
            // listGeneralSpecs = _manageHA.GetAllHA(_patient.CPR);
            //_generalSpec = (GeneralSpec)_patient.GeneralSpecs[Lb_OldHearingLeft.SelectedIndex];
            // generalSpec = (GeneralSpec)_patient.GeneralSpecs[Lb_OldHearingLeft.SelectedIndex];



            if (Lb_OldHearingRight.SelectedIndex >= 0)
            {
                generalSpec = listGeneralSpecs[Lb_OldHearingRight.SelectedIndex];

                Tb_EarSide.Text = Convert.ToString(generalSpec.EarSide);
                Tb_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_ID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                Tb_CreateDate.Text = Convert.ToString(generalSpec.CreateDate);
                Tb_StaffID.Text = Convert.ToString(generalSpec.StaffID);

                Lb_OldHearingRight.SelectedIndex = -1;

            }
            else if (Lb_OldHearingLeft.SelectedIndex >= 0)
            {
                generalSpec = listGeneralSpecs[Lb_OldHearingLeft.SelectedIndex];

                Tb_EarSide.Text = Convert.ToString(generalSpec.EarSide);
                Tb_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_ID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                Tb_CreateDate.Text = Convert.ToString(generalSpec.CreateDate);
                Tb_StaffID.Text = Convert.ToString(generalSpec.StaffID);

                Lb_OldHearingLeft.SelectedIndex = -1;

            }
            else
            {
                MessageBox.Show("Vælg et høreapparat");
            }

        

            
            
            //Tb_OldHearingAid.Text = "Øre: " + Convert.ToString(generalSpec.EarSide) + "\r\nDato " + Convert.ToString(generalSpec.CreateDate) + "\r\nFarve : " + Convert.ToString(generalSpec.Color);

            //foreach (var item in listGeneralSpecs)
            //{
            //    if (Lb_OldHearingLeft.SelectedItems.ToString() == "Dato: " + item.CreateDate)
            //    {
            //        Tblock_OldHearingAid.Text = "Øre: " + Convert.ToString(item.EarSide) + "\r\nDato " + Convert.ToString(item.CreateDate) + "\r\nFarve : " + Convert.ToString(item.Color);
            //    }
            //}



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

