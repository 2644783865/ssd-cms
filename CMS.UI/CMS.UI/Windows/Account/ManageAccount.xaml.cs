using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Account
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : MetroWindow
    {
        private IAuthenticationCore authCore;

        public ManageAccount()
        {
            InitializeComponent();
            authCore = new AuthenticationCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            ProgressSpin.IsActive = true;
            await FillRoleBox();
            ProgressSpin.IsActive = false;
        }

        private async Task FillRoleBox()
        {
            RoleBox.ClearValue(ItemsControl.ItemsSourceProperty);
            RoleBox.DisplayMemberPath = "Name";
            RoleBox.SelectedValuePath = "RoleId";
            RoleBox.ItemsSource = await authCore.GetHRRolesAsync();
        }

        private async Task FillAccountRoleBox()
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    AccountRoleBox.ClearValue(ItemsControl.ItemsSourceProperty);
                    AccountRoleBox.DisplayMemberPath = "Name";
                    AccountRoleBox.SelectedValuePath = "RoleId";
                    AccountRoleBox.ItemsSource = await authCore.GetRolesForOtherAccountAsync(LoginBox.Text);
                }
                else MessageBox.Show("Account doesn't exists");
            }
            else MessageBox.Show("Login is empty");
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditAccount newAddAccountWindow = new AddEditAccount(null);
            newAddAccountWindow.ShowDialog();
        }

        private async void AssignRole_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (RoleBox.SelectedIndex >= 0 && LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    if (await authCore.SetRoleForConferenceAndAccountAsync(UserCredentials.Conference.ConferenceId, LoginBox.Text,
                        int.Parse(RoleBox.SelectedValue.ToString())))
                        MessageBox.Show("Success");
                    else MessageBox.Show("Failure");
                }
                else MessageBox.Show("Account doesn't exists");
            }
            else MessageBox.Show("Not enough data");
            ProgressSpin.IsActive = false;
        }

        private async void RemoveRole_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (AccountRoleBox.SelectedIndex >= 0 && LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    if (await authCore.DeleteRoleForConferenceAndAccountAsync(UserCredentials.Conference.ConferenceId, LoginBox.Text,
                        int.Parse(AccountRoleBox.SelectedValue.ToString())))
                    {
                        await FillAccountRoleBox();
                        MessageBox.Show("Success");
                    }
                    else MessageBox.Show("Failure");
                }
                else MessageBox.Show("Account doesn't exists");
            }
            else MessageBox.Show("Not enough data");
            ProgressSpin.IsActive = false;
        }

        private async void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                    AddEditAccount newAddAccountWindow = new AddEditAccount(account);
                    newAddAccountWindow.ShowDialog();
                }
                else MessageBox.Show("Account doesn't exist");
            }
            else MessageBox.Show("Login empty");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }

        private async Task<bool> CheckAccountExistsAsync()
        {
            return await authCore.GetAccountIdByLoginAsync(LoginBox.Text) >= 0;
        }

        private async void LoadRoles_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            await FillAccountRoleBox();
            ProgressSpin.IsActive = false;
        }
    }
}
