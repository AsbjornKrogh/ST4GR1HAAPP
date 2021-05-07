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
using System.Windows.Shapes;
using BBL_Clinician;
using CoreEFTest.Models;

namespace Presentation_Clinician
{
    /// <summary>
    /// Interaction logic for HAInformationWindow.xaml
    /// </summary>
    public partial class HAInformationWindow : Window
    {
        UC3_ManageHA manageHA = new UC3_ManageHA();
        GeneralSpec _generalSpec = new GeneralSpec();
        ClinicianMainWindow _clinicianMain = new ClinicianMainWindow();
        //private List<GeneralSpec> listGeneralSpecs;


        public HAInformationWindow(ClinicianMainWindow clinicianMainWindow, UC3_ManageHA manageHa)
        {
            InitializeComponent();
            _clinicianMain = clinicianMainWindow;
            _manageHA = manageHa;

        }

        private void HAInformationWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            var listGeneralSpecs = _manageHA.GetAllHA(_clinicianMain.CPR);

            foreach (var clinicianSpec in listGeneralSpecs)
            {
                if (clinicianSpec != null)
                {
                    Lb_OldHearing.Items.Add( "øre: " + clinicianSpec.EarSide);
                    Lb_OldHearing.Items.Add("Dato:" + clinicianSpec.CreateDate);
                }
                else
                {
                    Lb_OldHearing.Items.Add("patienten har ingen tidligere høreapparater");
                }
            }
            
        }
    }
}
