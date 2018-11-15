using CMS.Core.Core;
using CMS.Core.Core.Authentication;
using CMS.Core.Interfaces.Authentication;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for ConferenceHome.xaml
    /// </summary>
    public partial class ConferenceHome : MetroWindow
    {
        private IAuthenticationCore core;

        public ConferenceHome()
        {
            InitializeComponent();
            core = new AuthenticationCore();
            WindowHelper.WindowSettings(this);
            UserLabel.Content = UserCredentials.Username;
            InitializeData();
        }

        private void InitializeData()
        {
            core.LoadRolesAsync();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            if (WindowHelper.CheckOtherWindows())
            {
                UserCredentials.Clear();
                LogIn newLoginWindow = new LogIn();
                newLoginWindow.Show();
                Close();
            }
        }

        private void GoToUserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UserPanel newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }
    }
}
