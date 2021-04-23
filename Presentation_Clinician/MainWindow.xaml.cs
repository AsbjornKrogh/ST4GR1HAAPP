using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
using BLL_Clinician;

namespace Presentation_Clinician
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
       
       UC2_ManagePatient managePatient = new UC2_ManagePatient();
       UC3_ManageHA manageHA = new UC3_ManageHA();
       ProcessClinPage processClinPage = new ProcessClinPage();
       private HomeWindow homeWindow;
       private PatientPage patientPage;
       private ManageHAPage manageHaPage;
       //private HearingTestWindow hearingTest;

        public bool LoginOK { get; set; }
       public string CPR { get; set; }

       Color color1 = Color.FromRgb(237,246,253);
       Color color2 = Color.FromRgb(226, 230, 230);

      public MainWindow()
      {
         InitializeComponent();
         homeWindow = new HomeWindow(this,managePatient);

      }
      public void Window_Loaded(object sender, RoutedEventArgs e)
      {
          Hide();
          homeWindow.ShowDialog();

          if (LoginOK)
          {
              Main.Content = new PatientPage(this, managePatient);
              ShowDialog();
          }
          else
          {
              MessageBox.Show("Fejl ved loginOK -- MainWindow");
          }
      }

        private void BtnPatient_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PatientPage(this, managePatient);
            BtnPatient.Background = new SolidColorBrush(color1);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            homeWindow = new HomeWindow(this, managePatient);
            homeWindow.TbCPRnumber.Clear();
            homeWindow.ShowDialog();

            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color1);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);

        }

        private void BtnHearingAid_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ManageHAPage(this, manageHA);
            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color1);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnProces_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = processClinPage;
            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color1);
        }
   }
}
