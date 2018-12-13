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
        public ViewTaskSchedule()
        {
            InitializeComponent();
            WindowHelper.WindowSettings(this, UserLabel, ConferenceLabel);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }
    }
}
