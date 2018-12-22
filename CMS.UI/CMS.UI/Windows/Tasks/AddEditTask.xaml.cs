using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para AddTask.xaml
    /// </summary>
    public partial class AddTask : MetroWindow
    {

        private ITaskCore taskCore;
        private ISessionCore sessionCore;
        private TaskDTO currentTask = null;
        private AccountDTO currentAccount;
        private bool isAutomatic = false;
        private Border BeginBorderError;

        public Border EndBorderError { get; private set; }

        public AddTask()
        {
            InitializeComponent();
            taskCore = new TaskCore();
            InitializeData();
        }

        private void InitializeData()
        {
            ProgressSpin.IsActive = true;
            ClearEventBoxes();
            //await LoadEmployees();
            ProgressSpin.IsActive = false;
        }

        private void ClearEventBoxes()
        {
            TitleBox.Text = string.Empty;
            DescriptionBox.Text = string.Empty;
            RoleEmployeeBox.SelectedIndex = -1;
            BeginDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
        }

        /*private async Task LoadEmployees()
        {
            RoleEmployeeBox.Items.Clear();
            RoleEmployeeBox.DisplayMemberPath = "Name";
            RoleEmployeeBox.SelectedValuePath = "EmployeeID";
            var employees = await  here we need the function get ID of emplyees by conference, or accounts in conference
            foreach (var employee in employees)
            {
              RoleEmployeeBox.Items.Add(employee);
            }
            

        }*/

        //private Task FillRoleBox()
        //{
        /*RoleBox.Items.Clear();
        RoleBox.DisplayMemberPath = "Employee";
        RoleBox.SelectedValuePath = "AccountId";
       // var roles = await authCore.GetHRRolesAsync();
        foreach (var Employee in Emplyees)
        {
            RoleBox.Items.Add(Employee);
        }*/
        //}


        private void FillEventBoxes()
        {
            if (currentTask != null)
            {
                TitleBox.Text = currentTask.Title;
                DescriptionBox.Text = currentTask.Title;
                RoleEmployeeBox.SelectedIndex = currentTask.EmployeeId;
                BeginDatePicker.SelectedDate = currentTask.BeginDate;
                EndDatePicker.SelectedDate = currentTask.EndDate;

            }
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(BeginDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate, BeginBorderError) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(EndDatePicker.SelectedDate.HasValue
                && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate >= BeginDatePicker.SelectedDate
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate), EndBorderError) ? false : result;
            return result;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var response = await sessionCore.CheckOverlappingSessiondAsync(UserCredentials.Conference.ConferenceId,
                        BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value);
                if (response != null && !response.Status)
                {
                    if (response != null)//here we need to think to changed for the task the line inside the if is something to not do it an error
                    {
                        currentTask.ConferenceId = UserCredentials.Conference.ConferenceId;
                        currentTask.Title = TitleBox.Text;
                        currentTask.Description = DescriptionBox.Text;
                        currentTask.BeginDate = BeginDatePicker.SelectedDate.Value;
                        currentTask.EndDate = EndDatePicker.SelectedDate.Value;
                        //error currentTask.EmployeeId = RoleEmployeeBox.SelectedIndex >= 0 ? (int?)
                        if (await taskCore.EditTaskAsync(currentTask))
                        {
                            MessageBox.Show("Successfully edited task");
                            InitializeData();
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
                           // error EmployeeId = RoleEmployeeBox.SelectedIndex >= 0 ? (int?)RoleEmployeeBox.SelectedValue : null
                        };
                        if (await taskCore.AddTaskAsync(newTask))
                        {
                            MessageBox.Show("Successfully added new task");
                            InitializeData();
                        }
                        else MessageBox.Show("Error occured while adding new task");
                    }
                }
                else if (response == null) MessageBox.Show("Error occured while adding new task");
                else MessageBox.Show(response.Message);
            }
            else MessageBox.Show("Invalid form");
        }
    }

}






        