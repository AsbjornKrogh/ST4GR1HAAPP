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
using CoreEFTest.Models;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for ManageHAPage.xaml
    /// </summary>
    public partial class ManageHAPage : Page
    {
        MainWindow mainWindow = new MainWindow();
        UC3_ManageHA manageHA = new UC3_ManageHA();

        private HearingTestWindow _hearingTest;
        private OrderNewHA orderNewHa;

        GeneralSpec generalSpec = new GeneralSpec();
        HAInformationWindow _haInformation = new HAInformationWindow();
        
        
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
        }

        private void BtnFormerHearingAids_Click(object sender, RoutedEventArgs e)
        {
            _haInformation = new HAInformationWindow();
            _haInformation.Show();
         //TbAllHA.Text = Convert.ToString(manageHA.GetAllHA(mainWindow.CPR));
        }

        private void HA_Page_Loaded(object sender, RoutedEventArgs e)
        {
            var HA_GeneralSpec = manageHA.GetHA(mainWindow.CPR);

            foreach (var generalSpec in HA_GeneralSpec)
            {
            
                    if (generalSpec.EarSide == Ear.Left)
                    {
                        Tb_LeftEar_Color.Text = Convert.ToString(generalSpec.Color);
                        Tb_LeftEar_Type.Text = Convert.ToString(generalSpec.Type);
                        Tb_Left_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                        Tb_StaffID_Left.Text = Convert.ToString(generalSpec.StaffID);
                        Tb_Datetime_Left.Text = Convert.ToString(generalSpec.CreateDate);
                    }
                    else

                    if (generalSpec.EarSide == Ear.Right)
                {
                    Tb_RightEar_Color.Text = Convert.ToString(generalSpec.Color);
                    Tb_RightEar_Type.Text = Convert.ToString(generalSpec.Type);
                    Tb_Right_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
                    Tb_StaffID_Right.Text = Convert.ToString(generalSpec.StaffID);
                    Tb_Datetime_Right.Text = Convert.ToString(generalSpec.CreateDate);
                }
                else
                {
                    MessageBox.Show("Ingen informatioer om høreapparat for højre øre");
                }
            }

          
            

        }

        private void BtnOrderHearingAids_Click(object sender, RoutedEventArgs e)
        {
            orderNewHa = new OrderNewHA();
            orderNewHa.Show();
        }
    }
}
