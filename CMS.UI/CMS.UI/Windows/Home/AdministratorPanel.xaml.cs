﻿using CMS.Core.Core;
using CMS.Core.Interfaces;
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

        private async void InitializeData()
        {
            ProgressSpin.IsActive = true;
            await FillRoleBox();
            await FillConferenceBox();
            ProgressSpin.IsActive = false;
        }

        private async Task FillRoleBox()
        {
            RoleBox.Items.Clear();
            RoleBox.DisplayMemberPath = "Name";
            RoleBox.SelectedValuePath = "RoleId";
            var roles = await authCore.GetAllRolesAsync();
            foreach (var role in roles)
            {
                RoleBox.Items.Add(role);
            }
        }

        private async Task FillConferenceBox()
        {
            ConferencesBox.DisplayMemberPath = "Title";
            ConferencesBox.SelectedValuePath = "ConferenceId";
            ConferencesBox.Items.Clear();
            var conferences = await confCore.GetConferencesAsync();
            foreach (var conference in conferences)
            {
                ConferencesBox.Items.Add(conference);
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
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

        private async void RemoveRole_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (RoleBox.SelectedIndex >= 0 && ConferencesBox.SelectedIndex >= 0 && LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    if (await authCore.DeleteRoleForConferenceAndAccountAsync(int.Parse(ConferencesBox.SelectedValue.ToString()), LoginBox.Text,
                        int.Parse(RoleBox.SelectedValue.ToString())))
                        MessageBox.Show("Success");
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
            return await authCore.GetAccountIdByLoginAsync(LoginBox.Text) >= 0;
        }

        private void EditConference_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented");
        }

        private async void RemoveConference_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ConferencesBox.SelectedIndex >= 0)
            {
                if (await confCore.DeleteConferenceAsync(int.Parse(ConferencesBox.SelectedValue.ToString()))) MessageBox.Show("Success");
                else MessageBox.Show("Failure");
            }
            else MessageBox.Show("Select conference");
            ProgressSpin.IsActive = false;
            InitializeData();
        }

        private async void RemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            var accountId = await authCore.GetAccountIdByLoginAsync(LoginBox.Text);
            if (accountId > 0)
            {
                if (await authCore.DeleteAccountAsync(accountId)) MessageBox.Show("Success");
                else MessageBox.Show("Failure");
            }
            else MessageBox.Show("Account doesn't exit!");
            ProgressSpin.IsActive = false;
        }
    }
}
