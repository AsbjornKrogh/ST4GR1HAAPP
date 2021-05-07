﻿using System;
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
        HearingTestWindow _hearingTest = new HearingTestWindow();
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
            //mainWindow.Hide();
        }

        private void BtnFormerHearingAids_Click(object sender, RoutedEventArgs e)
        {
            _haInformation = new HAInformationWindow();
            _haInformation.Show();
         //TbAllHA.Text = Convert.ToString(manageHA.GetAllHA(mainWindow.CPR));
        }

        private void HA_Page_Loaded(object sender, RoutedEventArgs e)
        {
            manageHA.GetHA(mainWindow.CPR);

            if (generalSpec.EarSide == Ear.Left)
            {
                Tb_LeftEar_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_LeftEar_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Left_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
            }
            
            if(generalSpec.EarSide == Ear.Right)
            {
                Tb_RightEar_Color.Text = Convert.ToString(generalSpec.Color);
                Tb_RightEar_Type.Text = Convert.ToString(generalSpec.Type);
                Tb_Right_HAID.Text = Convert.ToString(generalSpec.HAGeneralSpecID);
            }

            Tb_StaffID.Text = Convert.ToString(generalSpec.StaffID);
            Tb_Datetime.Text = Convert.ToString(generalSpec.CreateDate);



        }
    }
}
