using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
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
        private EventDTO currentEvent = null;
        private bool isAutomatic = false;
        public AddEditEvent()
        {
            InitializeComponent();
            eventCore = new EventCore();
            roomCore = new RoomCore();
            NewButton_Click(null, null);
            InitializeData();
        }

        private async void InitializeData()
        {
            InitializeTimeBoxes();
            await LoadBuildings();
            await LoadEvents();
        }

        private void InitializeTimeBoxes()
        {
            for (var i=0; i<=23; i++)
            {
                BeginHour.Items.Add(i);
                EndHour.Items.Add(i);
            }
            for (var i = 0; i <= 59; i++)
            {
                BeginMinute.Items.Add(i);
                EndMinute.Items.Add(i);
            }
            BeginHour.SelectedValue = 0;
            EndHour.SelectedValue = 0;
            BeginMinute.SelectedValue = 0;
            EndMinute.SelectedValue = 0;
        }

        private void ClearEventBoxes()
        {
            TitleBox.Text = string.Empty;
            DescriptionBox.Text = string.Empty;
            BuildingBox.SelectedIndex = -1;
            RoomBox.SelectedIndex = -1;
            BeginDatePicker.SelectedDate = null;
            EndDatePicker.SelectedDate = null;
            BeginHour.SelectedValue = 0;
            EndHour.SelectedValue = 0;
            BeginMinute.SelectedValue = 0;
            EndMinute.SelectedValue = 0;
        }

        private async Task LoadEvents()
        {
            SelectEventBox.Items.Clear();
            SelectEventBox.DisplayMemberPath = "Title";
            SelectEventBox.SelectedValuePath = "EventId";
            var events = await eventCore.GetEventsAsync(UserCredentials.Conference.ConferenceId);
            foreach (var @event in events)
            {
                SelectEventBox.Items.Add(@event);
            }
        }

        private async Task LoadBuildings()
        {
            BuildingBox.Items.Clear();
            BuildingBox.DisplayMemberPath = "Name";
            BuildingBox.SelectedValuePath = "BuildingID";
            var buildings = await roomCore.GetAssignedBuildingsForConferenceAsync(UserCredentials.Conference.ConferenceId);
            foreach (var building in buildings)
            {
                BuildingBox.Items.Add(building);
            }
            RoomBox.Items.Clear();
            
        }

        private async Task LoadRoomsForBuilding(int buildingId)
        {
            RoomBox.Items.Clear();
            RoomBox.DisplayMemberPath = "Code";
            RoomBox.SelectedValuePath = "RoomID";
            var rooms = await roomCore.GetRoomsForBuildingAsync(buildingId);
            foreach (var room in rooms)
            {
                RoomBox.Items.Add(room);
            }
        }

        private async void FillEventBoxes()
        {
            if (currentEvent != null)
            {
                TitleBox.Text = currentEvent.Title;
                DescriptionBox.Text = currentEvent.Title;
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
                BeginHour.SelectedValue = currentEvent.BeginDate.Hour;
                BeginMinute.SelectedValue = currentEvent.BeginDate.Minute;
                EndDatePicker.SelectedDate = currentEvent.EndDate;
                EndHour.SelectedValue = currentEvent.EndDate.Hour;
                EndMinute.SelectedValue = currentEvent.EndDate.Minute;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }


        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(BeginDatePicker.SelectedDate.HasValue, BeginDatePicker) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(EndDatePicker.SelectedDate.HasValue && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate >= BeginDatePicker.SelectedDate), EndDatePicker) ? false : result;
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

        private void Submitbutton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {

            }
            else MessageBox.Show("Invalid form");
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
