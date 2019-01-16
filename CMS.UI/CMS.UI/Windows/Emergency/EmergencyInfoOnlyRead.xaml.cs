using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.UI.Helpers;

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
            WindowHelper.SmallWindowSettings(this);
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
                EmergencyNumLabel.Text = emergency.EmergencyNum;
                EmergencyInfoLabel.Text = emergency.EmergencyInfo1;
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
