﻿using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using CMS.UI.Windows.Rooms;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            authCore = new AuthenticationCore();
            confCore = new ConferenceCore();
            UserCredentials.Username = "Admin";
            InitializeData();
        }

        private async void InitializeData()
        {
            ProgressSpin.IsActive = true;
            await FillRoleBox();
            await FillConferenceBox();
            ProgressSpin.IsActive = false;
            assignBuildings_button.IsEnabled = false;
        }

        private async Task FillRoleBox()
        {
            RoleBox.ClearValue(ItemsControl.ItemsSourceProperty);
            RoleBox.DisplayMemberPath = "Name";
            RoleBox.SelectedValuePath = "RoleId";
            RoleBox.ItemsSource = await authCore.GetAllRolesAsync();
        }

        private async Task FillConferenceBox()
        {
            ConferencesBox.DisplayMemberPath = "Title";
            ConferencesBox.SelectedValuePath = "ConferenceId";
            ConferencesBox.ClearValue(ItemsControl.ItemsSourceProperty);
            ConferencesBox.ItemsSource = await confCore.GetConferencesAsync();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditAccount newAddAccountWindow = new AddEditAccount(null);
            newAddAccountWindow.ShowDialog();
        }

        private async void AssignRole_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (RoleBox.SelectedIndex >= 0 && ConferencesBox.SelectedIndex >= 0 && LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    if (await authCore.SetRoleForConferenceAndAccountAsync(((ConferenceDTO)ConferencesBox.SelectedItem).ConferenceId, LoginBox.Text,
                        ((RoleDTO)RoleBox.SelectedItem).RoleId))
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
                    if (await authCore.DeleteRoleForConferenceAndAccountAsync(((ConferenceDTO)ConferencesBox.SelectedItem).ConferenceId, LoginBox.Text,
                        ((RoleDTO)RoleBox.SelectedItem).RoleId))
                        MessageBox.Show("Success");
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

        private void AddConference_Click(object sender, RoutedEventArgs e)
        {
            Conference.AddEditConference newAddConferenceWindow = new Conference.AddEditConference(null);
            newAddConferenceWindow.ShowDialog();
        }

        private async Task<bool> CheckAccountExistsAsync()
        {
            return await authCore.GetAccountIdByLoginAsync(LoginBox.Text) >= 0;
        }

        private async void EditConference_Click(object sender, RoutedEventArgs e)
        {
            if (ConferencesBox.SelectedIndex >= 0)
            {
                var conference = await confCore.GetConferenceByIdAsync(int.Parse(ConferencesBox.SelectedValue.ToString()));
                Conference.AddEditConference newAddConferenceWindow = new Conference.AddEditConference(conference);
                newAddConferenceWindow.ShowDialog();
            }
            else MessageBox.Show("Select conference");
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

        private void ManageBuilding_Click(object sender, RoutedEventArgs e)
        {
            ManageBuildingWindow newManageBuilding = new ManageBuildingWindow();
            newManageBuilding.ShowDialog();
        }

        private async void MetroWindow_Activated(object sender, System.EventArgs e)
        {
            await FillConferenceBox();
        }

        private void assignBuildings_button_Click(object sender, RoutedEventArgs e)
        {
            ConferenceDTO selected_conference = (ConferenceDTO)ConferencesBox.SelectedItem;
            if(selected_conference != null)
            {
                AssignBuildingToConference newAssignBuildingWindow = new AssignBuildingToConference(selected_conference);
                newAssignBuildingWindow.ShowDialog();
            }

        }

        private void ConferencesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConferenceDTO selected = (ConferenceDTO)ConferencesBox.SelectedItem;
            if(selected != null)
            {
                assignBuildings_button.IsEnabled = true;
            } else
            {
                assignBuildings_button.IsEnabled = false;
            }
           
        }
    }
}
