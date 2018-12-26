using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;


namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para AddTask.xaml
    /// </summary>
    public partial class AddEditTask : MetroWindow
    {
        private ITaskCore taskCore;
        private IAuthenticationCore authCore;
        private TaskDTO currentTask = null;

        public AddEditTask(TaskDTO task)
        {
            InitializeComponent();
            taskCore = new TaskCore();
            authCore = new AuthenticationCore();
            currentTask = task;
            InitializeData();
        }

        private async void InitializeData()
        {
            ProgressSpin.IsActive = true;
            await LoadEmployees();
            if (currentTask != null) InitializeEditFields();
            ProgressSpin.IsActive = false;
        }

        private async void InitializeEditFields()
        {
            TitleBox.Text = currentTask.Title;
            RoleEmployeeBox.SelectedValue = currentTask.EmployeeId;
            DescriptionBox.Text = currentTask.Description;
            BeginDatePicker.SelectedDate = currentTask.BeginDate;
            EndDatePicker.SelectedDate = currentTask.EndDate;
            ManagerLabel.Content = (await authCore.GetAccountByIdAsync(currentTask.ManagerId)).AccountId;
            SubmitButton.Content = "Save";
            Title = "Edit Task";
        }

        private async Task LoadEmployees()
        {
            RoleEmployeeBox.Items.Clear();
            RoleEmployeeBox.DisplayMemberPath = "Name";
            RoleEmployeeBox.SelectedValuePath = "AccountId";
            RoleEmployeeBox.ItemsSource = await taskCore.GetAccountsForConferenceEmployeeAsync(UserCredentials.Conference.ConferenceId);
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(BeginDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate.AddMonths(-6)
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate.AddDays(7), BeginDateErrorBorder) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(EndDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate.Value >= BeginDatePicker.SelectedDate.Value
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate.AddMonths(-6)
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate.AddDays(7)
                && BeginDatePicker.SelectedDate.Value.AddMinutes(10) <= EndDatePicker.SelectedDate.Value
                && BeginDatePicker.SelectedDate.Value.AddHours(12) >= EndDatePicker.SelectedDate.Value
                , EndDateErrorBorder) ? false : result;
            result = !ValidationHelper.ValidateComboBox(RoleEmployeeBox.SelectedIndex >= 0, RoleEmployeeBox) ? false : result;
            return result;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm())
            {
                var response = await taskCore.CheckOverlappingTaskAsync(((AccountDTO)RoleEmployeeBox.SelectedItem).AccountId, 
                    BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value);
                if (response)
                {
                    if (currentTask != null)
                    {
                        currentTask.Title = TitleBox.Text;
                        currentTask.Description = DescriptionBox.Text;
                        currentTask.BeginDate = BeginDatePicker.SelectedDate.Value;
                        currentTask.EndDate = EndDatePicker.SelectedDate.Value;
                        currentTask.EmployeeId = ((AccountDTO)RoleEmployeeBox.SelectedItem).AccountId;
                        currentTask.ManagerId = UserCredentials.Account.AccountId;
                        if (await taskCore.EditTaskAsync(currentTask))
                        {
                            MessageBox.Show("Successfully edited task");
                            Close();
                        }
                        else MessageBox.Show("Error occured while editing task");
                    }
                    else
                    {
                        var newTask = new TaskDTO()
                        {
                            ConferenceId = UserCredentials.Conference.ConferenceId,
                            Title = TitleBox.Text,
                            Description = DescriptionBox.Text,
                            BeginDate = BeginDatePicker.SelectedDate.Value,
                            EndDate = EndDatePicker.SelectedDate.Value,
                            EmployeeId = ((AccountDTO)RoleEmployeeBox.SelectedItem).AccountId,
                            ManagerId = UserCredentials.Account.AccountId
                        };
                        if (await taskCore.AddTaskAsync(newTask))
                        {
                            MessageBox.Show("Successfully added new task");
                            Close();
                        }
                        else MessageBox.Show("Error occured while adding new task");
                    }
                }
                else
                {
                    MessageBox.Show("There is an overlapping task for this employee");
                }
            }
            else MessageBox.Show("Invalid form");
            ProgressSpin.IsActive = false;
        }
    }
}






