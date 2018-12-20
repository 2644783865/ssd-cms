using CMS.BE.DTO;
using CMS.Core.Core;
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

namespace CMS.UI.Windows.Tasks
{
    /// <summary>
    /// Lógica de interacción para ManageTasks.xaml
    /// </summary>
    public partial class ManageTasksWindow : MetroWindow
    {

        private TaskCore core;

        public int ConferenceId { get; private set; }

        public ManageTasksWindow(int conferenceID)
        {
            
            InitializeComponent();
            core = new TaskCore();
            loadTasksToDatagrid(conferenceID);
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        async private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            TaskDTO taskToDelete = (TaskDTO)TasksList.SelectedItem;
            await core.DeleteTaskAsync(taskToDelete.TaskID);
            loadTasksToDatagrid(ConferenceId);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTask NewAddTaskWindow = new AddTask();
            NewAddTaskWindow.Show();
            Close();
        }

        async private void loadTasksToDatagrid(int conferenceID)
        {

            TasksList.ItemsSource = await core.GetTasksAsync(conferenceID);
            
        }
    }
}
