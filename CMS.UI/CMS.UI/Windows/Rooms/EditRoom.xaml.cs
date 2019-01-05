using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Rooms
{
    /// <summary>
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    public partial class EditRoom : MetroWindow
    {
        private RoomDTO room_being_edited;
        private int BuildingID;
        IRoomCore core;
        public EditRoom(RoomDTO arg_edit_room, int arg_BuildingID)
        {
            core = new RoomCore(); 
            this.room_being_edited = arg_edit_room;
            this.BuildingID = arg_BuildingID;
            InitializeComponent();
            InitializeData();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (newroomname.Text.Length > 0)
            {
                RoomDTO new_possible_code_room = room_being_edited;
                new_possible_code_room.Code = newroomname.Text;
                bool response = await core.EditRoomAsync(new_possible_code_room);
                if (response)
                {
                    this.room_being_edited = new_possible_code_room;
                    InitializeData();
                    MessageBox.Show("Successfully edited!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Could not edit the room's code!");
                }
            }
            else MessageBox.Show("Code cannot be empty");
        }

        async private void InitializeData()
        {
            oldroomname.Text = room_being_edited.Code;
            BuildingDTO building_of_room = await core.GetBuildingByIdAsync(this.BuildingID);
            // add building name and address  to the window title so it is easier to know which room is edited
            this.Title = this.Title + " - " +building_of_room.Name + ", " + building_of_room.Address;
        }

    }
}
