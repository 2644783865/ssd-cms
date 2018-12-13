using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
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
    public partial class AddTask : MetroWindow
    {

        private TaskDTO currentTask;

        public void AddEditTask(TaskDTO task)
        {
            InitializeComponent();
            //await FillRoleBox();
            currentTask = task;
            if (task != null) InitializeEditFields();
        }

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

        private void InitializeEditFields()
        {
            //RoleEmployeeBox.SelectedValuePath = currentTask.EmployeeId;
            TitleBox.Text = currentTask.Title;
            DescriptionBox.Text = currentTask.Description;
            BeginDatePicker.SelectedDate = currentTask.BeginDate;
            EndDatePicker.SelectedDate = currentTask.EndDate;
            SubmitButton.Content = "Save";
            this.Title = "Edit Task";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private  void SubmitButton_Click(object sender, RoutedEventArgs e)
        {


            ProgressSpin.IsActive = true;
            if (ValidateForm())
            {
                using (IAuthenticationCore core = new AuthenticationCore())
                {
                    bool result = false;

                    if (currentTask == null)
                    {
                        var newTask = new TaskDTO()
                        {
                            ConferenceId = UserCredentials.Conference.ConferenceId,
                            ManagerId = UserCredentials.Account.AccountId,
                            //EmployeeId = RoleEmployeeBox.SelectedValue,
                            Title = TitleBox.Text,
                            Description = DescriptionBox.Text,
                            BeginDate = BeginDatePicker.SelectedDate.Value,
                            EndDate = EndDatePicker.SelectedDate.Value
                        };
                       // result = await core.AddTask(newTask);
                    }
                    else
                    {
                        currentTask.Title = TitleBox.Text;
                        currentTask.Description = DescriptionBox.Text;
                        currentTask.BeginDate = BeginDatePicker.SelectedDate.Value;
                        currentTask.EndDate = EndDatePicker.SelectedDate.Value;

                        //result = await core.EditTaskAsync(currentTask);
                    }

                    if (result)
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failure");
                    }
                }
            }
            else MessageBox.Show("Form invalid");
            ProgressSpin.IsActive = false;
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(BeginDatePicker.SelectedDate.HasValue, BeginDatePicker) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(EndDatePicker.SelectedDate.HasValue && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate >= BeginDatePicker.SelectedDate), EndDatePicker) ? false : result;
            return result;
        }

        private void TitleBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
