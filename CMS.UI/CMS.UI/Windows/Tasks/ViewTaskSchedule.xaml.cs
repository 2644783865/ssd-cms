using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.UI.Helpers;
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
    /// Lógica de interacción para ViewTaskSchedule.xaml
    /// </summary>
    public partial class ViewTaskSchedule : MetroWindow
    {
        private TaskCore core;
        private int employeeId;

        public ViewTaskSchedule(int? employeeID)
        {
            InitializeComponent();
            core = new TaskCore();
            if (employeeID == null)
            {
                employeeId = UserCredentials.Account.AccountId;
            }
            else
            {
                employeeId = employeeID.Value;
            }
            
            LoadTasksForToDatagrid();
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

        async private void LoadTasksForToDatagrid()
        {
            TaskDataGrid.ItemsSource = await core.GetTasksForEmployeeAsync(employeeId, UserCredentials.Conference.ConferenceId);
        }
    }
}
