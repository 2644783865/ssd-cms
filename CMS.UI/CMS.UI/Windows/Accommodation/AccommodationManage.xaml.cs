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

namespace CMS.UI.Windows.Accommodation
{
    /// <summary>
    /// Interaction logic for AccomodationManage.xaml
    /// </summary>
    public partial class AccommodationManage : MetroWindow
    {
        public AccommodationManage()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AccommodationInfo newAddAccommodationWindow = new AccommodationInfo(null);
            newAddAccommodationWindow.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            // var account = DATAGRID INFO
            AccommodationInfo newAddAccommodationWindow = new AccommodationInfo(null /*accommodation*/);
            newAddAccommodationWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
