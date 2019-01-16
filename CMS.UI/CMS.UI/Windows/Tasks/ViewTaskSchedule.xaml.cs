using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para ViewTaskSchedule.xaml
    /// </summary>
    public partial class ViewTaskSchedule : MetroWindow
    {
        private ITaskCore taskCore;
        private AccountDTO currentEmployee;

        public ViewTaskSchedule(bool isEmployee)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            taskCore = new TaskCore();
            LoadEmployees();
            if (isEmployee)
            {
                HideChooseEmployee();
                currentEmployee = UserCredentials.Account; 
                LoadTasksForToDatagrid(currentEmployee.AccountId);
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
            EmployeeBox.ClearValue(ItemsControl.ItemsSourceProperty);
            EmployeeBox.DisplayMemberPath = "Name";
            EmployeeBox.SelectedValuePath = "AccountId";
            EmployeeBox.ItemsSource = await taskCore.GetAccountsForConferenceEmployeeAsync(UserCredentials.Conference.ConferenceId);
        }

        async private void LoadTasksForToDatagrid(int employeeId)
        {
            TaskDataGrid.ItemsSource = await taskCore.GetTasksForEmployeeAsync(employeeId, UserCredentials.Conference.ConferenceId);
        }

        private void EmployeeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeBox.SelectedIndex >= 0)
            {
                currentEmployee = (AccountDTO)EmployeeBox.SelectedItem;
                LoadTasksForToDatagrid(currentEmployee.AccountId);
            }
        }

        private async void DownloadICal_Click(object sender, RoutedEventArgs e)
        {
            DownloadICal.IsEnabled = false;
            try
            {
                var document = await taskCore.GetTaskScheduleICalAsync(currentEmployee.AccountId, UserCredentials.Conference.ConferenceId);
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "ics files (*.ics)|*.ics",
                    FileName = $"{UserCredentials.Conference.Title} tasks schedule for {currentEmployee.Name} iCal.ics"
                };

                if ((bool)saveFileDialog.ShowDialog())
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {
                        writer.Write(document);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot override the file. The file may be opened.");
            }
            catch
            {
                MessageBox.Show("Error downloading schedule iCal");
            }
            DownloadICal.IsEnabled = true;
        }
    }
}
