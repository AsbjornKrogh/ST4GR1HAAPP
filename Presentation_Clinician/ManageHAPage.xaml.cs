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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BBL_Clinician;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for ManageHAPage.xaml
    /// </summary>
    public partial class ManageHAPage : Page
    {
        MainWindow mainWindow = new MainWindow();
        UC3_ManageHA manageHA = new UC3_ManageHA();
        
        public ManageHAPage(MainWindow mainWindow, UC3_ManageHA manageHA)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.manageHA = manageHA;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRetrieveHearingTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFormerHearingAids_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
