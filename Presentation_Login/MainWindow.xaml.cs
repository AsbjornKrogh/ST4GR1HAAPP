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
using BLL_Login;
using DTO;

namespace Presentation_Login
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      //Class Init
      private readonly DB_BLL_Login dbBllLogin;

      public MainWindow()
      {
         InitializeComponent();
         dbBllLogin = new DB_BLL_Login();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void LoginDB_Click(object sender, RoutedEventArgs e)
      {
         LoginMetode();
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PasswordTB_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter) 
            LoginMetode();
      }

      /// <summary>
      /// 
      /// </summary>
      private void LoginMetode()
      {
         string StaffID = MedarbejderIDTB.Text;
         string PW = PasswordTB.Password;

         DTO_StaffLogin dtoStaffLogin = dbBllLogin.CheckLogin(StaffID, PW);

         if (dtoStaffLogin.StaffStatus == StaffStatus.Technician)
         {
            //Todo go to technician side of the program 
         }
         else
         {
            //Todo go to clinician side of the program 
         }
      }
   }
}
