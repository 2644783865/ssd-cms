using CMS.Core.Core;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;
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
    /// Interaction logic for AuthorPanel.xaml
    /// </summary>
    public partial class AuthorPanel : MetroWindow
    {
        public AuthorPanel()
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

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditArticles_Click(sender, e);
        }

        private void AddArticles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditArticles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
