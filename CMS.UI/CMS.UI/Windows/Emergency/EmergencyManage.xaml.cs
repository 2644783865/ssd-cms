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

namespace CMS.UI.Windows.Emergency
{
    /// <summary>
    /// Interaction logic for EmergencyManage.xaml
    /// </summary>
    public partial class EmergencyManage : MetroWindow
    {
        public EmergencyManage()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            EmergencyInfo newAddEmergencyWindow = new EmergencyInfo(null);
            newAddEmergencyWindow.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            // var emergency = DATAGRID INFO
            EmergencyInfo newAddEmergencyWindow = new EmergencyInfo(null /*emergency*/);
            newAddEmergencyWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
