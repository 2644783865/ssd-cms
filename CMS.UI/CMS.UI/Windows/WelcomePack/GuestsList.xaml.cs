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
using MahApps.Metro.Controls;

namespace CMS.UI.Windows.WelcomePack
{
    /// <summary>
    /// Interaction logic for GuestsList.xaml
    /// </summary>
    public partial class GuestsList : MetroWindow
    {
        public GuestsList()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            GuestAdd newWindow = new GuestAdd();
            newWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
