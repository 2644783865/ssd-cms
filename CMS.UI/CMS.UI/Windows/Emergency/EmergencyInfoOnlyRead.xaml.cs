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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;

namespace CMS.UI.Windows.Emergency
{
    /// <summary>
    /// Interaction logic for EmergencyInfoOnlyRead.xaml
    /// </summary>
    public partial class EmergencyInfoOnlyRead : MetroWindow
    {
        private IEmergencyInfoCore emergencyCore;
        public EmergencyInfoOnlyRead()
        {
            InitializeComponent();
            emergencyCore = new EmergencyInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadLabels();
        }

        private async Task LoadLabels()
        {
            var emergency = await emergencyCore.GetEmergencyInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);

            if (emergency != null)
            {
                EmergencyNumLabel.Content = emergency.EmergencyNum;
                EmergencyInfoLabel.Content = emergency.EmergencyInfo1;
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
