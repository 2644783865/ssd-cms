using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using MahApps.Metro.Controls;
using System.Linq;
using System.Threading.Tasks;
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
            WindowHelper.WindowSettings(this, UserLabel);
            InitializeData();
        }

        private async void InitializeData()
        {
            ProgressSpin.IsActive = true;
            await FillConferenceBox();
            ProgressSpin.IsActive = false;
        }

        private async Task FillConferenceBox()
        {
            ConferencesBox.Items.Clear();
            await core.LoadConferencesAsync();
            foreach (var conference in UserCredentials.Conferences)
            {
                ConferencesBox.Items.Add($"{conference.ConferenceId} {conference.Title} {conference.BeginDate.ToShortDateString()}");
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToConferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferencesBox.SelectedIndex >= 0)
            {
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferencesBox.SelectedIndex);
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
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferencesBox.SelectedIndex);
                ManagerPanel newWindow = new ManagerPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private void GoToAuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferencesBox.SelectedIndex >= 0)
            {
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferencesBox.SelectedIndex);
                AuthorPanel newWindow = new AuthorPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
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
