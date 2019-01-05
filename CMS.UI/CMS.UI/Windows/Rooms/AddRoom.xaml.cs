using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class AddRoomsWindow : MetroWindow
    {
        private int BuildingID;
        private String defaultInputText;
        IRoomCore core;
        public AddRoomsWindow(int arg_buildingID)
        {
            core = new RoomCore();
            this.BuildingID = arg_buildingID;
            InitializeComponent();
            defaultInputText = roomnumber.Text;
        }

        async private void addRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (roomnumber.Text.Length > 0)
            {
                RoomDTO newroom = new RoomDTO();
                newroom.BuildingID = this.BuildingID;
                newroom.Code = roomnumber.Text;
                bool response = await core.AddRoomAsync(newroom);
                if (response)
                {
                    MessageBox.Show("Successfully added!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Could not add the room!");
                }
            }
            else MessageBox.Show("Code cannot be empty");
        }

        private void roomnumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if (roomnumber.Text.Equals(defaultInputText))
            {
                roomnumber.Text = "";
            }
            
        }
    }
}
