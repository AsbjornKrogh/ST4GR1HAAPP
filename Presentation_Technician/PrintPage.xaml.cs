using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation_Technician
{
    /// <summary>
    /// Interaction logic for PrintPage.xaml
    /// </summary>
    public partial class PrintPage : Page
    {
        private bool isRunning;

        public PrintPage()
        {
            InitializeComponent();
        }

        private void FindAllPatientsB_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning != true)
            {
                string CPR = CPRnummerTB.Text;
                if (CPR.Length == 11 && CPR.Contains('-'))
                {
                    isRunning = true;

                    BackgroundWorker worker = new BackgroundWorker();


                    //worker.DoWork += ;

                    //worker.RunWorkerCompleted += UC3GetPatientCompleted;

                    //worker.RunWorkerAsync(CPR);

                    Loading.Visibility = Visibility.Visible;
                    Loading.Spin = true;

                    Thread.Sleep(1500);
                    MessageBox.Show("Der blev ikke fundet nogle høreapparater, der er klar til print");

                }
                else
                {
                    MessageBox.Show("Indtast gyldigt CPR");

                }
            }
        }

        private void FindScanB_Click(object sender, RoutedEventArgs e)
        {
            if (isRunning != true)
            {
                string CPR = CPRnummerTB.Text;
                if (CPR.Length == 11 && CPR.Contains('-'))
                {
                    isRunning = true;

                    BackgroundWorker worker = new BackgroundWorker();


                    Loading.Visibility = Visibility.Visible;
                    Loading.Spin = true;

                    Thread.Sleep(1500);
                    MessageBox.Show("Der blev ikke fundet nogle høreapparater, der er klar til print");



                }
                else
                {
                    MessageBox.Show("Indtast gyldigt CPR");

                }
            }
        }
    }
}
