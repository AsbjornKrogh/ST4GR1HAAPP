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
        HearingTestWindow _hearingTest = new HearingTestWindow();
        
        public ManageHAPage(MainWindow mainWindow, UC3_ManageHA manageHA)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.manageHA = manageHA;
            
        }


        private void BtnRetrieveHearingTest_Click(object sender, RoutedEventArgs e)
        {
            _hearingTest = new HearingTestWindow();
            _hearingTest.Show();
            //mainWindow.Hide();
        }

        private void BtnFormerHearingAids_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
