using CMS.Core.Core;
using CMS.Core.Core.Authentication;
using CMS.Core.Interfaces.Authentication;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using MahApps.Metro.Controls;
using System.Linq;
using System.Windows;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : MetroWindow
    {
        private IAuthenticationCore core;

        public UserPanel()
        {
            InitializeComponent();
            core = new AuthenticationCore();
            WindowHelper.WindowSettings(this);
            UserLabel.Content = UserCredentials.Username;
            InitializeData();
        }

        private void InitializeData()
        {
            ProgressSpin.IsActive = true;
            core.LoadConferencesAsync(ConferencesBox);
            ProgressSpin.IsActive = false;
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

        private void GoToConferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferencesBox.SelectedIndex >= 0)
            {
                UserCredentials.ConferenceId = UserCredentials.Conferences.ElementAt(ConferencesBox.SelectedIndex).ConferenceId;
                ConferenceHome newWindow = new ConferenceHome();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private void GoToManagerPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferencesBox.SelectedIndex >= 0)
            {
                //UserCredentials.ConferenceId = UserCredentials.Conferences.ElementAt(ConferencesBox.SelectedIndex).ConferenceId;
                MessageBox.Show("Not implemented");
            }
            else MessageBox.Show("Choose conference");
        }

        private void GoToAuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowHelper.CheckOtherWindows())
            {
                ChangePassword newChangePasswordWindow = new ChangePassword();
                newChangePasswordWindow.Show();
                Close();
            }
        }
    }
}
