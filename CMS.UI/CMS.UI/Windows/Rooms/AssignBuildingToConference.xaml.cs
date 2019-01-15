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
    /// Interaction logic for AssignBuildingToConference.xaml
    /// </summary>
    public partial class AssignBuildingToConference : MetroWindow
    {
        IRoomCore core = new RoomCore();
        private ConferenceDTO current_conference;
        private int conferenceId; 
        public AssignBuildingToConference(ConferenceDTO arg_conferenceID)
        {
            this.Title = this.Title + arg_conferenceID.Title;
            this.current_conference = arg_conferenceID;
            this.conferenceId = current_conference.ConferenceId;
            InitializeComponent();
            assignButton.IsEnabled = false;
            unassignButton.IsEnabled = false;
            InitializeData();
        }


        private async void InitializeData()
        {
            List<BuildingDTO> unassigned_buildings = await core.GetUnassignedBuildingsForConferenceAsync(this.conferenceId);
            List<BuildingDTO> assigned_buildings = await core.GetAssignedBuildingsForConferenceAsync(this.conferenceId);
            unassignedlist.ItemsSource = unassigned_buildings;
            assignedlist.ItemsSource = assigned_buildings;
        }

        private async void assignButton_Click(object sender, RoutedEventArgs e)
        {
            BuildingDTO selectedBuildingToAssign = (BuildingDTO)unassignedlist.SelectedItem;
            if(selectedBuildingToAssign != null)
            {
                bool response = await core.SetBuildingForConferenceAsync(this.conferenceId, selectedBuildingToAssign.BuildingID);
                if (response)
                {
                    InitializeData();
                }
            }
        }

        private async void unassignButton_Click(object sender, RoutedEventArgs e)
        {
            BuildingDTO selectedBuildingToUnAssign = (BuildingDTO)assignedlist.SelectedItem;
            if (selectedBuildingToUnAssign != null)
            {
                bool response = await core.DeleteBuildingForConferenceAsync(this.conferenceId, selectedBuildingToUnAssign.BuildingID);
                if (response)
                {
                    InitializeData();
                }
            }

        }

        private void unassignedlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuildingDTO unassginedlist_selecteditem = (BuildingDTO)unassignedlist.SelectedItem;
            if (unassginedlist_selecteditem != null)
            {
                assignButton.IsEnabled = true;
               
            } else
            {
                assignButton.IsEnabled = false;
            }
            unassignButton.IsEnabled = false;

        }

        private void assignedlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BuildingDTO assignedlist_selecteditem = (BuildingDTO)assignedlist.SelectedItem;
            if (assignedlist_selecteditem != null)
            {
                unassignButton.IsEnabled = true;

            }
            else
            {
                unassignButton.IsEnabled = false;
            }
            assignButton.IsEnabled = false;
        }
    }
}
