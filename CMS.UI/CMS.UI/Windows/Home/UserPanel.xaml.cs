using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : MetroWindow
    {
        private IAuthenticationCore core;
        private IAuthorCore authorCore;
        public UserPanel()
        {
            InitializeComponent();
            core = new AuthenticationCore();
            authorCore = new AuthorCore();
            WindowHelper.WindowSettings(this, UserLabel);
            InitializeData();
        }

        private async void InitializeData()
        {
            UserCredentials.Author = await authorCore.GetAuthorByAccountIdAsync(UserCredentials.Account.AccountId);
            ProgressSpin.IsActive = true;
            await FillConferenceList();
            FillUserData();
            SetButtonVisibility(false);
            ProgressSpin.IsActive = false;
        }

        private void SetButtonVisibility(bool isManager)
        {
            GoToAuthorPanelButton.Visibility = UserCredentials.Author != null ? Visibility.Visible : Visibility.Collapsed;
            GoToManagerPanelButton.Visibility = isManager ? Visibility.Visible : Visibility.Collapsed;
        }

        private async Task FillConferenceList()
        {
            ConferenceList.ClearValue(ItemsControl.ItemsSourceProperty);
            await core.LoadConferencesAsync();
            ConferenceList.DisplayMemberPath = "ConferenceDesc";
            ConferenceList.SelectedValuePath = "ConferenceId";
            ConferenceList.ItemsSource = UserCredentials.Conferences;
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

        private async void GoToConferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                ConferenceHome newWindow = new ConferenceHome();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private async void GoToManagerPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                ManagerPanel newWindow = new ManagerPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private async void GoToAuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                AuthorPanel newWindow = new AuthorPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
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

        private async void ConferenceList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                var result = await core.CheckIsManager(((ConferenceDTO)ConferenceList.SelectedItem).ConferenceId);
                SetButtonVisibility(result);
            }
        }
    }
}
