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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class RoomWindow : MetroWindow
    {
        private RoomCore core;
        private int BuildingID;
        public RoomWindow(int building)
        {
            BuildingID = building;
            InitializeComponent();
            EditRoom.IsEnabled = false;
            DeleteRoom.IsEnabled = false;
            core = new RoomCore();
            LoadRoomsToDataGrid(building);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomsWindow newAddRoomsWindow = new AddRoomsWindow(this.BuildingID);
            newAddRoomsWindow.Show();
            Close();
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO roomtoedit = (RoomDTO)RoomList.SelectedItem;
            EditRoom newEditRoomsWindow = new EditRoom(roomtoedit);
            newEditRoomsWindow.ShowDialog();
            Close();
        }

        async private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO roomtodelete = (RoomDTO)RoomList.SelectedItem;
            await core.DeleteRoomAsync(roomtodelete.RoomID);
            LoadRoomsToDataGrid(BuildingID);
        }

        async private void LoadRoomsToDataGrid(int building)
        {
            RoomList.ItemsSource = await core.GetRoomsForBuildingAsync(building);

        }

        private void RoomList_CurrentCellChanged(object sender, EventArgs e)
        {
            EditRoom.IsEnabled = true;
            DeleteRoom.IsEnabled = true;
        }
    }
}
