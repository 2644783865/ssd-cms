using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para ViewTaskSchedule.xaml
    /// </summary>
    public partial class ViewTaskSchedule : MetroWindow
    {
        private ITaskCore taskCore;

        public ViewTaskSchedule(bool isEmployee)
        {
            InitializeComponent();
            taskCore = new TaskCore();
            LoadEmployees();
            if (isEmployee)
            {
                HideChooseEmployee();
                LoadTasksForToDatagrid(UserCredentials.Account.AccountId);
            }
            else ShowChooseEmployee();
        }

        private void ShowChooseEmployee()
        {
            ChooseEmpLabel.Visibility = Visibility.Visible;
            EmployeeBox.Visibility = Visibility.Visible;
        }

        private void HideChooseEmployee()
        {
            ChooseEmpLabel.Visibility = Visibility.Hidden;
            EmployeeBox.Visibility = Visibility.Hidden;
        }

        private async void LoadEmployees()
        {
            EmployeeBox.Items.Clear();
            EmployeeBox.DisplayMemberPath = "Name";
            EmployeeBox.SelectedValuePath = "AccountId";
            EmployeeBox.ItemsSource = await taskCore.GetAccountsForConferenceEmployeeAsync(UserCredentials.Conference.ConferenceId);
        }

        async private void LoadTasksForToDatagrid(int employeeId)
        {
            TaskDataGrid.ItemsSource = await taskCore.GetTasksForEmployeeAsync(employeeId, UserCredentials.Conference.ConferenceId);
        }

        private void EmployeeBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (EmployeeBox.SelectedIndex >= 0)
            LoadTasksForToDatagrid(((AccountDTO)EmployeeBox.SelectedItem).AccountId);
        }
    }
}
