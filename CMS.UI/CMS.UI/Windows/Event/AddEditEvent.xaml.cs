﻿using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Event
{
    /// <summary>
    /// Lógica de interacción para AddEditEvent.xaml
    /// </summary>
    public partial class AddEditEvent : MetroWindow
    {
        private IEventCore eventCore;
        private IRoomCore roomCore;
        private ISessionCore sessionCore;
        private EventDTO currentEvent = null;
        private bool isAutomatic = false;
        public AddEditEvent()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            eventCore = new EventCore();
            roomCore = new RoomCore();
            sessionCore = new SessionCore();
            NewButton_Click(null, null);
            InitializeData();
        }

        private async void InitializeData()
        {
            try
            {
                ProgressSpin.IsActive = true;
                ClearEventBoxes();
                await LoadBuildings();
                await LoadEvents();
                ProgressSpin.IsActive = false;
            }
            catch
            {
                Close();
            }
        }

        private void ClearEventBoxes()
        {
            TitleBox.Text = string.Empty;
            DescriptionBox.Text = string.Empty;
            BuildingBox.SelectedIndex = -1;
            RoomBox.SelectedIndex = -1;
            BeginDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
        }

        private async Task LoadEvents()
        {
            SelectEventBox.ClearValue(ItemsControl.ItemsSourceProperty);
            SelectEventBox.DisplayMemberPath = "Title";
            SelectEventBox.SelectedValuePath = "EventId";
            SelectEventBox.ItemsSource = await eventCore.GetEventsAsync(UserCredentials.Conference.ConferenceId);
        }

        private async Task LoadBuildings()
        {
            BuildingBox.ClearValue(ItemsControl.ItemsSourceProperty);
            BuildingBox.DisplayMemberPath = "Name";
            BuildingBox.SelectedValuePath = "BuildingID";
            BuildingBox.ItemsSource = await roomCore.GetAssignedBuildingsForConferenceAsync(UserCredentials.Conference.ConferenceId);
            RoomBox.ClearValue(ItemsControl.ItemsSourceProperty);
        }

        private async Task LoadRoomsForBuilding(int buildingId)
        {
            RoomBox.ClearValue(ItemsControl.ItemsSourceProperty);
            RoomBox.DisplayMemberPath = "Code";
            RoomBox.SelectedValuePath = "RoomID";
            RoomBox.ItemsSource = await roomCore.GetRoomsForBuildingAsync(buildingId);
        }

        private async void FillEventBoxes()
        {
            if (currentEvent != null)
            {
                TitleBox.Text = currentEvent.Title;
                DescriptionBox.Text = currentEvent.Description;
                if (currentEvent.RoomId.HasValue)
                {
                    var room = await roomCore.GetRoomByIdAsync(currentEvent.RoomId.Value);
                    isAutomatic = true;
                    BuildingBox.SelectedValue = room.BuildingID;
                    await LoadRoomsForBuilding(room.BuildingID);
                    RoomBox.SelectedValue = currentEvent.RoomId;
                    isAutomatic = false;
                }
                else
                {
                    BuildingBox.SelectedIndex = -1;
                    RoomBox.SelectedIndex = -1;
                }
                BeginDatePicker.SelectedDate = currentEvent.BeginDate;
                EndDatePicker.SelectedDate = currentEvent.EndDate;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }


        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(BeginDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate, BeginBorderError) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(EndDatePicker.SelectedDate.HasValue
                && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate.Value >= BeginDatePicker.SelectedDate.Value
                && BeginDatePicker.SelectedDate.Value.AddHours(5) >= EndDatePicker.SelectedDate.Value
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate), EndBorderError) ? false : result;
            return result;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            currentEvent = null;
            SelectEventBox.SelectedIndex = -1;
            ClearEventBoxes();
            Submitbutton.Content = "Add";
            DeleteButton.Visibility = Visibility.Hidden;
        }

        private async void SelectEventBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectEventBox.SelectedIndex >= 0)
            {
                currentEvent = await eventCore.GetEventByIdAsync(int.Parse(SelectEventBox.SelectedValue.ToString()));
                FillEventBoxes();
                Submitbutton.Content = "Confirm";
            }
            else NewButton_Click(null, null);
        }

        private async void Submitbutton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            Submitbutton.IsEnabled = false;
            if (ValidateForm())
            {
                var response = await sessionCore.CheckOverlappingSessionAsync(UserCredentials.Conference.ConferenceId,
                        BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value, currentEvent != null ? currentEvent.EventId : 0);
                if (response != null && !response.Status)
                {
                    if (SelectEventBox.SelectedIndex >= 0)
                    {
                        currentEvent.ConferenceId = UserCredentials.Conference.ConferenceId;
                        currentEvent.Title = TitleBox.Text;
                        currentEvent.Description = DescriptionBox.Text;
                        currentEvent.BeginDate = BeginDatePicker.SelectedDate.Value;
                        currentEvent.EndDate = EndDatePicker.SelectedDate.Value;
                        currentEvent.RoomId = RoomBox.SelectedIndex >= 0 ? (int?)RoomBox.SelectedValue : null;
                        if (await eventCore.EditEventAsync(currentEvent))
                        {
                            MessageBox.Show("Successfully edited event");
                            InitializeData();
                        }
                        else MessageBox.Show("Error occured while editing event");
                    }
                    else
                    {
                        var newEvent = new EventDTO()
                        {
                            ConferenceId = UserCredentials.Conference.ConferenceId,
                            Title = TitleBox.Text,
                            Description = DescriptionBox.Text,
                            BeginDate = BeginDatePicker.SelectedDate.Value,
                            EndDate = EndDatePicker.SelectedDate.Value,
                            RoomId = RoomBox.SelectedIndex >= 0 ? (int?)RoomBox.SelectedValue : null
                        };
                        if (await eventCore.AddEventAsync(newEvent))
                        {
                            MessageBox.Show("Successfully added new event");
                            InitializeData();
                        }
                        else MessageBox.Show("Error occured while adding new event");
                    }
                }
                else if (response == null) MessageBox.Show("Error occured while adding new event");
                else MessageBox.Show(response.Message);
            }
            else MessageBox.Show("Invalid form");
            ProgressSpin.IsActive = false;
            Submitbutton.IsEnabled = true;
        }

        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearRoomButton_Click(object sender, RoutedEventArgs e)
        {
            RoomBox.SelectedIndex = -1;
            if (currentEvent != null) currentEvent.RoomId = null;
        }

        private async void BuildingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuildingBox.SelectedIndex >= 0 && !isAutomatic) await LoadRoomsForBuilding(int.Parse(BuildingBox.SelectedValue.ToString()));
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectEventBox.SelectedIndex >= 0)
            {
                if (await eventCore.DeleteEventAsync(currentEvent.EventId))
                {
                    MessageBox.Show("Successfully deleted event");
                    InitializeData();
                }
                else MessageBox.Show("Error occured while deleting event");
            }
        }
    }
}
