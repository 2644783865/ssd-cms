﻿using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

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
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            BuildingID = building;
            core = new RoomCore();
            InitializeTitle();
            HideButtonsOnUnselectedCell();
            LoadRoomsToDataGrid(building);
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoomsWindow newAddRoomsWindow = new AddRoomsWindow(this.BuildingID);
            newAddRoomsWindow.ShowDialog();
            //this can be improved by tracking user's adding activity
            LoadRoomsToDataGrid(this.BuildingID);
            HideButtonsOnUnselectedCell();
        }

        async private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO roomtoedit = (RoomDTO)RoomList.SelectedItem;
            int focusID = roomtoedit.RoomID;  
            EditRoom newEditRoomsWindow = new EditRoom(roomtoedit, BuildingID);
            newEditRoomsWindow.ShowDialog();
            //this can be improved by tracking user's editing activity
            //await needed here explicitly, requires clarification
            // do not lose focus on cell after editing
            RoomList.ItemsSource = await core.GetRoomsForBuildingAsync(this.BuildingID);
            foreach (RoomDTO row in this.RoomList.Items)
            {

                int currentRoomID = row.RoomID;
                if (currentRoomID.Equals(focusID))
                {
                    RoomList.CurrentCell = new DataGridCellInfo(row, RoomList.Columns[0]);
                    RoomList.SelectedItem = row;
                    break;
                }
            }

                
        }

        async private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO roomtodelete = (RoomDTO)RoomList.SelectedItem;
            await core.DeleteRoomAsync(roomtodelete.RoomID);
            LoadRoomsToDataGrid(BuildingID);
        }

        async private void LoadRoomsToDataGrid(int building)
        {
            RoomList.ClearValue(ItemsControl.ItemsSourceProperty);
            RoomList.ItemsSource = await core.GetRoomsForBuildingAsync(building);
        }

        private void RoomList_CurrentCellChanged(object sender, EventArgs e)
        {
            EditRoom.IsEnabled = true;
            DeleteRoom.IsEnabled = true;
        }

        async private void InitializeTitle()
        {
            BuildingDTO building_of_room = await core.GetBuildingByIdAsync(this.BuildingID);
            // add building name and address  to the window title so it is easier to know which room is edited
            this.Title = this.Title + " - " + building_of_room.Name + ", " + building_of_room.Address;
        }

        private void HideButtonsOnUnselectedCell()
        {
            EditRoom.IsEnabled = false;
            DeleteRoom.IsEnabled = false;
        }
    }
}
