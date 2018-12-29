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
    /// Interaction logic for EditRoom.xaml
    /// </summary>
    public partial class EditRoom : MetroWindow
    {
        private RoomDTO room_being_edited;
        IRoomCore core;
        public EditRoom(RoomDTO arg_edit_room)
        {
            core = new RoomCore(); 
            this.room_being_edited = arg_edit_room; 
            InitializeComponent();
            oldroomname.Text = room_being_edited.Code;
            newroomname.Text = "Enter a new name";
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoomDTO new_possible_code_room = room_being_edited;
            new_possible_code_room.Code = newroomname.Text;
            bool response = await core.EditRoomAsync(new_possible_code_room);
            if (response)
            {
                MessageBox.Show("Successfully edited!");
            }
            else
            {
                MessageBox.Show("Could not edit the room's code!");
            }
        }

    }
}
