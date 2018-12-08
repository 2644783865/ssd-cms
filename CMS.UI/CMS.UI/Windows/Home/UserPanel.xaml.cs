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
            await FillConferenceList();
            FillUserData();
            ProgressSpin.IsActive = false;
        }

        private async Task FillConferenceList()
        {
            ConferenceList.Items.Clear();
            await core.LoadConferencesAsync();
            foreach (var conference in UserCredentials.Conferences)
            {
                ConferenceList.Items.Add($"{conference.ConferenceId} {conference.Title} {conference.BeginDate.ToShortDateString()}");
            }
        }

        private void FillUserData()
        {
            IdLabel.Content = "Id: " + UserCredentials.Account.AccountId;
            NameLabel.Content = "Name: " + UserCredentials.Account.Name;
            LoginLabel.Content = "Login: " + UserCredentials.Account.Login;
            EmailLabel.Content = "Email: " + UserCredentials.Account.Email;
            PhoneLabel.Content = "Phone: " + UserCredentials.Account.PhoneNumber;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToConferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferenceList.SelectedIndex);
                ConferenceHome newWindow = new ConferenceHome();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private void GoToManagerPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferenceList.SelectedIndex);
                ManagerPanel newWindow = new ManagerPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private void GoToAuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = UserCredentials.Conferences.ElementAt(ConferenceList.SelectedIndex);
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
