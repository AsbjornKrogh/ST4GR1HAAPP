using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CoreEFTest.Models;
using DLL_Technician;

namespace Presentation_Technician
{
    /// <summary>
    /// Interaction logic for ProcessPage.xaml
    /// </summary>
    public partial class ProcessPage : Page
    {
        private IClinicDB db;
        private StaffLogin technician;
        private bool okIsRunning;
        public ProcessPage(IClinicDB db, StaffLogin login)
        {
            InitializeComponent();

            this.db = db;
            technician = login;
        }

        private void OKB_Click(object sender, RoutedEventArgs e)
        {
            ////    if (okIsRunning != true)
            ////    {
            ////        okIsRunning = true;

            ////        BackgroundWorker worker = new BackgroundWorker();

            ////        worker.DoWork += UC4GetPatientInformation;

            ////        worker.RunWorkerCompleted += UC4GetPatientInformationCompleted;

            ////        string castID = HACastIDTB.Text;
            ////        worker.RunWorkerAsync(castID);

            ////        Loading.Visibility = Visibility.Visible;
            ////        Loading.Spin = true;
            ////    }

        }
    }
}
