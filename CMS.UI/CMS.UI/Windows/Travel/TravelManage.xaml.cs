﻿using System;
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

namespace CMS.UI.Windows.Travel
{
    /// <summary>
    /// Interaction logic for TravelManage.xaml
    /// </summary>
    public partial class TravelManage : MetroWindow
    {
        public TravelManage()
        {
            InitializeComponent();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            TravelInfo newAddTravelWindow = new TravelInfo(null);
            newAddTravelWindow.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            // var travel = DATAGRID INFO
            TravelInfo newAddTravelWindow = new TravelInfo(null/*travel*/);
            newAddTravelWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
