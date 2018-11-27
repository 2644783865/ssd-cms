using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
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
    }
}
