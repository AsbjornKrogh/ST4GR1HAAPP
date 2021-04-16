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
      public TechnicianMainWindow()
      {
         InitializeComponent();

        //db = new ClinicDB();
         db = new ClinicNoDB();
         ;
      }


      private void HovedmenuB_Click(object sender, RoutedEventArgs e)
      {
          Main.Content = null;
          HovedmenuB.IsEnabled = false;
          ManageHAB.IsEnabled = true;
      }
        private void ManageHAB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HAInfoPage(db);
            ManageHAB.IsEnabled = false;
            HovedmenuB.IsEnabled = true;
        }

        private void ScanB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ScanPage(db);
            ScanB.IsEnabled = false;
            HovedmenuB.IsEnabled = true;
        }

        private void PrintB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HovedmenuB.IsEnabled = false;
        }
    }
}
