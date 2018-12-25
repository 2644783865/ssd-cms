using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using CMS.UI.Windows.Author;
using CMS.UI.Windows.Award;
using CMS.UI.Windows.Event;
using CMS.UI.Windows.Tasks;
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

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : MetroWindow
    {
        public ManagerPanel()
        {
            InitializeComponent();
            WindowHelper.WindowSettings(this, UserLabel, ConferenceLabel);
            SetVisibility();
        }

        private void SetVisibility()
        {
            var test = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceManager) || r.Name.Equals(Properties.RoleResources.ConferenceChair));
            if ( test == null)
            {
                ManageTasks.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceStaffManager)) != null ? Visibility.Visible : Visibility.Hidden;
                ManageAccount.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.HRAdministrator)) != null ? Visibility.Visible : Visibility.Hidden;
                ManageAuthor.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.HRAdministrator)) != null ? Visibility.Visible : Visibility.Hidden;
                ManageEvent.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null ? Visibility.Visible : Visibility.Hidden;
                ManageAward.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.AwardsCoordinator)) != null ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToUserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UserPanel newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }

        private void GoToConferenceHomeButton_Click(object sender, RoutedEventArgs e)
        {
            ConferenceHome newWindow = new ConferenceHome();
            newWindow.Show();
            Close();
        }

        private void ManageAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ManageAccount newWindow = new ManageAccount();
            newWindow.ShowDialog();
        }

        private void ManageAuthor_Click(object sender, RoutedEventArgs e)
        {
            ManageAuthor newWindow = new ManageAuthor();
            newWindow.ShowDialog();
        }

        private void ManageEvent_Click(object sender, RoutedEventArgs e)
        {
            AddEditEvent newWindow = new AddEditEvent();
            newWindow.ShowDialog();
        }

        private void ManageAward_Click(object sender, RoutedEventArgs e)
        {
            ManageAwards newWindow = new ManageAwards();
            newWindow.ShowDialog();
        }

        private void ManageTasks_Click(object sender, RoutedEventArgs e)
        {
            ManageTasksWindow newWindow = new ManageTasksWindow();
            newWindow.ShowDialog();
        }
    }
}
