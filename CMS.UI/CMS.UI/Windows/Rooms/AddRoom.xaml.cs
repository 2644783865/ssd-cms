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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class AddRoomsWindow : MetroWindow
    {
        private int BuildingID;
        IRoomCore core;
        public AddRoomsWindow(int arg_buildingID)
        {
            core = new RoomCore();
            this.BuildingID = arg_buildingID;
            InitializeComponent();
        }

        async private void addRoomButton_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO newroom = new RoomDTO();
            newroom.BuildingID = this.BuildingID;
            newroom.Code = roomnumber.Text;
            bool response = await core.AddRoomAsync(newroom);
            if (response)
            {
                MessageBox.Show("Successfully added!");
            } else
            {
                MessageBox.Show("Could not add the room!");
            }
            
        }
    }
}
