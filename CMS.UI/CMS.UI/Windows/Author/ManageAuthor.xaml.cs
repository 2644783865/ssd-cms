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

namespace CMS.UI.Windows.Author
{
    /// <summary>
    /// Interaction logic for ManageAuthor.xaml
    /// </summary>
    public partial class ManageAuthor : MetroWindow
    {
        public ManageAuthor()
        {
            InitializeComponent();
        }

        private void GoToAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            AddEditAuthor newAddEditAuthorWindow = new AddEditAuthor();
            newAddEditAuthorWindow.ShowDialog();

        }

        private void GoToEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            AddEditAuthor newAddEditAuthorWindow = new AddEditAuthor();
            newAddEditAuthorWindow.ShowDialog();

        }

        private void GoToDeleteAuthor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
