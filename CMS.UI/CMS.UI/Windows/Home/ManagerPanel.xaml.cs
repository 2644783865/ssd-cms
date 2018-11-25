using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using MahApps.Metro.Controls;
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

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : MetroWindow
    {
        private IAuthenticationCore authCore;
        public ManagerPanel()
        {
            InitializeComponent();
            authCore = new AuthenticationCore();
            WindowHelper.WindowSettings(this, UserLabel, ConferenceLabel);
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
            RoleBox.Items.Clear();
            RoleBox.DisplayMemberPath = "Name";
            RoleBox.SelectedValuePath = "RoleId";
            var roles = await authCore.GetHRRolesAsync();
            foreach (var role in roles)
            {
                RoleBox.Items.Add(role);
            }
        }

        private async Task FillAccountRoleBox()
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    AccountRoleBox.Items.Clear();
                    AccountRoleBox.DisplayMemberPath = "Name";
                    AccountRoleBox.SelectedValuePath = "RoleId";
                    var roles = await authCore.GetRolesForOtherAccountAsync(LoginBox.Text);
                    foreach (var role in roles)
                    {
                        AccountRoleBox.Items.Add(role);
                    }
                }
                else MessageBox.Show("Account doesn't exists");
            }
            else MessageBox.Show("Login is empty");
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToUserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UserPanel newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }

        private void GoToConferenceHomeButton_Click(object sender, RoutedEventArgs e)
        {
            ConferenceHome newWindow = new ConferenceHome();
            newWindow.Show();
            Close();
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccount newAddAccountWindow = new AddAccount();
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

        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
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
