using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;


namespace CMS.UI.Windows.Emergency
{
    /// <summary>
    /// Interaction logic for EmergencyInfo.xaml
    /// </summary>
    public partial class EmergencyInfo : MetroWindow
    {
        private EmergencyInfoDTO currentEmergency;

        public EmergencyInfo(EmergencyInfoDTO emergency)
        {
            InitializeComponent();
            currentEmergency = emergency;
            if (emergency != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            currentEmergency.EmergencyNum= EmergencyNumBox.Text;
            currentEmergency.EmergencyInfo= EmergencyInfoBox.Text;

        }

    }
}

