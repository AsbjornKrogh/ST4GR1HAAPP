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
using DLL_Technician;

namespace Presentation_Technician
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class TechnicianMainWindow : Window
   {
       private IClinicDB db;
       private IScanner scanner;
      public TechnicianMainWindow()
      {
         InitializeComponent();

        //db = new ClinicDB();
         db = new ClinicNoDB();

         scanner = new NoScanner();
      }


      private void HovedmenuB_Click(object sender, RoutedEventArgs e)
      {
          Main.Content = null;
          VelkommenL.Visibility = Visibility.Visible;
          HovedmenuB.IsEnabled = false;

          //Todo tilføj alle knapper her:
          ManageHAB.IsEnabled = true;
          ScanB.IsEnabled = true;
          ProcesB.IsEnabled = true;
        }

        private void ManageHAB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HAInfoPage(db);
            VelkommenL.Visibility = Visibility.Collapsed;
            ManageHAB.IsEnabled = false;

            //Todo tilføj alle knapper her:
            HovedmenuB.IsEnabled = true;
            ScanB.IsEnabled = true;
            ProcesB.IsEnabled = true;
            PrintB.IsEnabled = true;
        }

        private void ScanB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ScanPage(db,scanner);
            VelkommenL.Visibility = Visibility.Collapsed;
            ScanB.IsEnabled = false;

            //Todo tilføj alle knapper her:
            HovedmenuB.IsEnabled = true;
            ManageHAB.IsEnabled = true;
            ProcesB.IsEnabled = true;
            PrintB.IsEnabled = true;

        }

        private void PrintB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PrintPage();
            VelkommenL.Visibility = Visibility.Collapsed;
            PrintB.IsEnabled = false;

            //Todo tilføj alle knapper her:
            HovedmenuB.IsEnabled = true;
            ManageHAB.IsEnabled = true;
            ProcesB.IsEnabled = true;
            ScanB.IsEnabled = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HovedmenuB.IsEnabled = false;
        }

        private void ProcesB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProcessPage();
            VelkommenL.Visibility = Visibility.Collapsed;
            ProcesB.IsEnabled = false;

            //Todo tilføj alle knapper her:
            HovedmenuB.IsEnabled = true;
            ManageHAB.IsEnabled = true;
            PrintB.IsEnabled = true;
            ScanB.IsEnabled = true;
        }
    }
}
