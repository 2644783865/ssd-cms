using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
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

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class ManageBuildingWindow : MetroWindow
    {
        IRoomCore core;
        public ManageBuildingWindow()
        {
            core = new RoomCore();
            InitializeComponent();
            initializeBuildingList();
            editbuildingbutton.IsEnabled = false;
            deletebuildingbutton.IsEnabled = false;
        }

        async private void initializeBuildingList()
        {
            buildinglist.ItemsSource = await core.GetBuildingsAsync();
        }

        private void buildinglist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BuildingDTO current = (BuildingDTO)buildinglist.CurrentItem; 
            RoomWindow newRoomWindow = new RoomWindow(current.BuildingID);
            newRoomWindow.ShowDialog();

        }

        private void buildinglist_CurrentCellChanged(object sender, EventArgs e)
        {

           editbuildingbutton.IsEnabled = true;
           deletebuildingbutton.IsEnabled = true;

            
        }
    }
}
