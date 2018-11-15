using CMS.Core.Core;
using CMS.Core.Core.Authentication;
using CMS.Core.Core.Conference;
using CMS.Core.Interfaces.Authentication;
using CMS.Core.Interfaces.Conference;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for AdministratorPanel.xaml
    /// </summary>
    public partial class AdministratorPanel : MetroWindow
    {
        private IAuthenticationCore authCore;
        private IConferenceCore confCore;

        public AdministratorPanel()
        {
            authCore = new AuthenticationCore();
            confCore = new ConferenceCore();
            InitializeComponent();
            UserCredentials.Username = "Admin";
            InitializeData();
        }

        private void InitializeData()
        {
            ProgressSpin.IsActive = true;
            RoleBox.Items.Clear();
            ConferencesBox.Items.Clear();
            authCore.LoadAllRolesAsync(RoleBox);
            confCore.LoadConferencesAsync(ConferencesBox);
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

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccount newAddAccountWindow = new AddAccount();
            newAddAccountWindow.ShowDialog();
        }

        private async void AssignRole_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (RoleBox.SelectedIndex >= 0 && ConferencesBox.SelectedIndex >= 0 && LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    if (await authCore.SetRoleForConferenceAndAccountAsync(int.Parse(ConferencesBox.SelectedValue.ToString()), LoginBox.Text,
                        int.Parse(RoleBox.SelectedValue.ToString())))
                        MessageBox.Show("Success");
                    else MessageBox.Show("Failure");
                }
                else MessageBox.Show("Account doesn't exists");
            }
            else MessageBox.Show("Not enough data");
            ProgressSpin.IsActive = false;
        }

        private void RemoveRole_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private void AddConference_Click(object sender, RoutedEventArgs e)
        {
            Conference.AddConference newAddConferenceWindow = new Conference.AddConference();
            newAddConferenceWindow.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }

        private async Task<bool> CheckAccountExistsAsync()
        {
            return await authCore.GetAccountByLoginAsync(LoginBox.Text) >= 0;
        }
    }
}
