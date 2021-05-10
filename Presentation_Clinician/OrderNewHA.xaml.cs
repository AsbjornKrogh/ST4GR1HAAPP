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
using CoreEFTest.Models;
using BLL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for OrderNewHA.xaml
    /// </summary>
    public partial class OrderNewHA : Window
    {
        UC3_ManageHA manageHA = new UC3_ManageHA();
        ClinicianMainWindow _clinicianMainWindow= new ClinicianMainWindow();
        GeneralSpec generalSpec = new GeneralSpec();

        public OrderNewHA()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Cb_LeftEar.IsChecked == true)
            {
                generalSpec.EarSide = Ear.Left;
                generalSpec.CPR = _clinicianMainWindow.Patient.CPR;
                generalSpec.CreateDate = DateTime.Now;
                generalSpec.StaffID = _clinicianMainWindow.StaffID;
                CbNewColor.Text = generalSpec.Color.ToString();
                CbNewType.Text = generalSpec.Type.ToString();
            }
            else if (Cb_RightEar.IsChecked == true)
            {
                generalSpec.EarSide = Ear.Right;
                generalSpec.CPR = _clinicianMainWindow.Patient.CPR;
                generalSpec.CreateDate = DateTime.Now;
                generalSpec.StaffID = _clinicianMainWindow.StaffID;
                CbNewColor.Text = generalSpec.Color.ToString();
                CbNewType.Text = generalSpec.Type.ToString();
            }

            manageHA.CreateHA(generalSpec);
            MessageBox.Show("Høreapparatet er bestilt");
        }
    }
}
