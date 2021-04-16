using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Presentation_Clinician
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
       HomePage homePage = new HomePage();
       PatientPage patientPage = new PatientPage();
       ManageHAPage manageHaPage = new ManageHAPage();
       ProcessClinPage processClinPage = new ProcessClinPage();

       Color color1 = Color.FromRgb(237,246,253);
       Color color2 = Color.FromRgb(226, 230, 230);

      public MainWindow()
      {
         InitializeComponent();
         this.Content = homePage;
      }

        private void BtnPatient_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = patientPage;
            BtnPatient.Background = new SolidColorBrush(color1);
            BtnStart.Background = new SolidColorBrush(color2);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = homePage;
            BtnPatient.Background = new SolidColorBrush(color2);
            BtnStart.Background = new SolidColorBrush(color1);
            BtnHearingAid.Background = new SolidColorBrush(color2);
            BtnProces.Background = new SolidColorBrush(color2);
        }

        private void BtnHearingAid_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = manageHaPage;
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
