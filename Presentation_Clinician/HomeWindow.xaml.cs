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

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private UC2_ManagePatient uc2ManagePatient;
        public HomeWindow()
        {
            InitializeComponent();

            uc2ManagePatient = new UC2_ManagePatient();

            TbCPRnumber.Focus();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            string cpr = TbCPRnumber.Text;

            this.Close();

            //if (uc2ManagePatient.FindCPR(cpr))
            //{
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Ugyldigt CPR");
            //}
        }
    }
}
