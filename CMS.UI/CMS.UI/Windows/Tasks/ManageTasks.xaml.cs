using CMS.BE.DTO;
using CMS.Core.Core;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para ManageTasks.xaml
    /// </summary>
    public partial class ManageTasksWindow : MetroWindow
    {
        private TaskCore core;
        
        public ManageTasksWindow()
        {
            InitializeComponent();
            core = new TaskCore();
            loadTasksToDatagrid();
        }

        private async void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedIndex >= 0)
            {
                var task = await core.GetTaskByIdAsync(((TaskDTO)TasksList.SelectedItem).TaskId);
                AddEditTask newAddTaskWindow = new AddEditTask(task);
                newAddTaskWindow.ShowDialog();
            }
            else MessageBox.Show("Choose task first");
        }

        async private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedIndex >= 0)
            {
                var result = await core.DeleteTaskAsync(((TaskDTO)TasksList.SelectedItem).TaskId);
                if (result)
                {
                    MessageBox.Show("Successfully deleted task");
                    await loadTasksToDatagrid();
                }
                else MessageBox.Show("Error occured while deleting task");
            }
            else MessageBox.Show("Choose task first");
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditTask NewAddTaskWindow = new AddEditTask(null);
            NewAddTaskWindow.ShowDialog();
        }

        async private Task loadTasksToDatagrid()
        {
            TasksList.ItemsSource = await core.GetTasksAsync(UserCredentials.Conference.ConferenceId);
        }

        private void TasksList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            buttonEdit_Click(null, null);
        }

        private async void MetroWindow_Activated(object sender, System.EventArgs e)
        {
            await loadTasksToDatagrid();
        }

        private void ScheduleForEmployee_Click(object sender, RoutedEventArgs e)
        {
            ViewTaskSchedule newWindow = new ViewTaskSchedule(false);
            newWindow.ShowDialog();
        }
    }
}
