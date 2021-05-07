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
using BBL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for OrderNewHA.xaml
    /// </summary>
    public partial class OrderNewHA : Window
    {
        UC3_ManageHA manageHA = new UC3_ManageHA();
        ClinicianMainWindow mainWindow = new ClinicianMainWindow();
        GeneralSpec generalSpec = new GeneralSpec();
        Patient patient = new Patient();
        
        public OrderNewHA()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Cb_LeftEar.IsChecked == true)
            {
                generalSpec.EarSide = Ear.Left;
                generalSpec.CPR = mainWindow.CPR;
                generalSpec.CreateDate = DateTime.Now;
                generalSpec.StaffID = mainWindow.StaffID;
                TbNewColor.Text = generalSpec.Color.ToString();
                TbNewType.Text = patient.GeneralSpecs.ToString();
            }
            else if (Cb_RightEar.IsChecked == true)
            {
                generalSpec.EarSide = Ear.Right;
                generalSpec.CPR = mainWindow.CPR;
                generalSpec.CreateDate = DateTime.Now;
                generalSpec.StaffID = mainWindow.StaffID;
                TbNewColor.Text = generalSpec.Color.ToString();
                TbNewType.Text = generalSpec.Type.ToString();
            }
        }
    }
}
