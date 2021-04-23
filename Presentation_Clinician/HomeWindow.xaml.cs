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
        private MainWindow mainWindow;
        public HomeWindow(MainWindow mainWindow, UC2_ManagePatient managePatient)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.uc2ManagePatient = managePatient;

            TbCPRnumber.Focus();
        }

        private void BtOK_Click(object sender, RoutedEventArgs e)
        {
            string cpr = TbCPRnumber.Text;

            if (uc2ManagePatient.CheckCPR(cpr))
            {
                mainWindow.LoginOK = true;
                mainWindow.CPR = cpr;
                Hide();

            }
            else
            {
                mainWindow.LoginOK = false;
                string message = "Ugyldigt CPR";
                string title = "Fejl";
                MessageBoxImage error = MessageBoxImage.Error;
                MessageBox.Show(message, title, MessageBoxButton.OK, error);
            }
        }
    }
}
