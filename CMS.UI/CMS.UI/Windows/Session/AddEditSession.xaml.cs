using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Logika interakcji dla klasy AddSession.xaml
    /// </summary>
    public partial class AddEditSession : MetroWindow
    {
        private IAuthenticationCore authCore;
        private ISessionCore core;
        private IEventCore eventCore;
        private IRoomCore roomCore;
        private RoomDTO lastSelectedRoom = null;
        private SessionDTO currentSession = null;
        private SpecialSessionDTO currentSpecialSession = null;
        public AddEditSession(SessionDTO session, SpecialSessionDTO specialSession)
        {
            InitializeComponent();
            core = new SessionCore();
            authCore = new AuthenticationCore();
            eventCore = new EventCore();
            roomCore = new RoomCore();

            currentSession = session;
            currentSpecialSession = specialSession;
            if (currentSession != null) InitializeSessionFields();
            if (currentSpecialSession != null) InitializeSpecialSessionFields();
            Refresh_Click(null, null);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void InitializeSessionFields()
        {
            TitleBox.Text = currentSession.Title;
            BeginDatePicker.SelectedDate = currentSession.BeginDate;
            EndDatePicker.SelectedDate = currentSession.EndDate;
            ChairmanBox.Text = (await authCore.GetAccountByIdAsync(currentSession.ChairId)).Login;
            DescriptionBox.Text = currentSession.Description;
            lastSelectedRoom = await roomCore.GetRoomByIdAsync(currentSession.RoomId);
            SpecialSessionCheck.IsEnabled = false;
            Refresh_Click(null, null);
            Title = "Edit session";
            AddSessionButton.Content = "Submit";
        }

        private async void InitializeSpecialSessionFields()
        {
            TitleBox.Text = currentSpecialSession.Title;
            BeginDatePicker.SelectedDate = currentSpecialSession.BeginDate;
            EndDatePicker.SelectedDate = currentSpecialSession.EndDate;
            ChairmanBox.Text = (await authCore.GetAccountByIdAsync(currentSpecialSession.ChairId)).Login;
            DescriptionBox.Text = currentSpecialSession.Description;
            lastSelectedRoom = await roomCore.GetRoomByIdAsync(currentSpecialSession.RoomId);
            SpecialSessionCheck.IsChecked = true;
            SpecialSessionCheck.IsEnabled = false;
            Refresh_Click(null, null);
            Title = "Edit session";
            AddSessionButton.Content = "Submit";
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadBuildings();
            await LoadAvailableRooms();
        }

        private async Task LoadBuildings()
        {
            BuildingBox.ClearValue(ItemsControl.ItemsSourceProperty);
            BuildingBox.DisplayMemberPath = "Name";
            BuildingBox.SelectedValuePath = "BuildingID";
            BuildingBox.ItemsSource = await roomCore.GetAssignedBuildingsForConferenceAsync(UserCredentials.Conference.ConferenceId);
            if (RoomBox.SelectedIndex >= 0) lastSelectedRoom = (RoomDTO)RoomBox.SelectedItem;
            RoomBox.ClearValue(ItemsControl.ItemsSourceProperty);
            if (lastSelectedRoom != null) BuildingBox.SelectedValue = lastSelectedRoom.BuildingID;
        }

        private async Task LoadAvailableRooms()
        {
            if (RoomBox.SelectedIndex >= 0) lastSelectedRoom = (RoomDTO)RoomBox.SelectedItem;
            RoomBox.ClearValue(ItemsControl.ItemsSourceProperty);
            RoomBox.DisplayMemberPath = "Code";
            RoomBox.SelectedValuePath = "RoomID";
            var roomId = currentSession == null ? (currentSpecialSession == null ? 0 : currentSpecialSession.RoomId) : currentSession.RoomId;
            if (BeginDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue && BuildingBox.SelectedIndex >= 0)
                RoomBox.ItemsSource = await roomCore.GetAvailableRoomsAsync(((BuildingDTO)BuildingBox.SelectedItem).BuildingID,
                    BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value, roomId);
            if (lastSelectedRoom != null) RoomBox.SelectedValue = lastSelectedRoom.RoomID;
        }

        private async Task<bool> CheckChairman()
        {
            if (ChairmanBox.Text.Length > 0 && BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate)
            {
                var account = await authCore.GetAccountByLoginAsync(ChairmanBox.Text);

                if (account != null)
                {
                    var roles = await authCore.GetRolesForOtherAccountAsync(account.Login);
                    if (roles != null && roles.Exists(role => role.Name.Equals(Properties.RoleResources.SessionChair)))
                    {
                        var response = await core.CheckOverlappingSessionForChairmanAsync(account.AccountId, BeginDatePicker.SelectedDate.Value,
                            EndDatePicker.SelectedDate.Value, currentSession != null ? currentSession.SessionId : 0, currentSpecialSession != null 
                            ? currentSpecialSession.SpecialSessionId : 0);
                        if (response != null && !response.Status)
                        {
                            StatusChairman.Foreground = Brushes.Green;
                            StatusChairman.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSolid;
                            return true;
                        }
                    }
                    else MessageBox.Show("Given login is not a session chair or an error occured while checking the roles");
                }
            }
            StatusChairman.Foreground = Brushes.Red;
            StatusChairman.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.TimesCircleSolid;
            return false;
        }

        private async Task<bool> CheckDate()
        {
            if (BeginDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate)
            {
                var response = await eventCore.CheckOverlappingEventAsync(UserCredentials.Conference.ConferenceId,
                    BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value);
                if (response != null && !response.Status)
                {
                    StatusDate.Foreground = Brushes.Green;
                    StatusDate.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSolid;
                    return true;
                }
            }
            StatusDate.Foreground = Brushes.Red;
            StatusDate.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.TimesCircleSolid;
            return false;
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateDateTimePicker(BeginDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && BeginDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate, BeginBorder) ? false : result;
            result = !ValidationHelper.ValidateDateTimePicker(EndDatePicker.SelectedDate.HasValue
                && BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate.Value >= BeginDatePicker.SelectedDate.Value
                && EndDatePicker.SelectedDate.Value >= UserCredentials.Conference.BeginDate
                && EndDatePicker.SelectedDate.Value <= UserCredentials.Conference.EndDate, EndBorder) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(ChairmanBox.Text.Length > 0, ChairmanBox) ? false : result;
            result = !ValidationHelper.ValidateComboBox(RoomBox.SelectedIndex >= 0, RoomBox) ? false : result;
            result = !ValidationHelper.ValidateComboBox(BuildingBox.SelectedIndex >= 0, BuildingBox) ? false : result;
            return result;
        }

        private async void AddSessionButton_Click(object sender, RoutedEventArgs e)
        {
            AddSessionButton.IsEnabled = false;
            try
            {
                if (ValidateForm())
                {
                    if (await CheckDate() && await CheckChairman() && await CheckRoom())
                    {
                        if (currentSession == null && currentSpecialSession == null)
                        {
                            if (SpecialSessionCheck.IsChecked.Value)
                            {
                                var specialSession = new SpecialSessionDTO()
                                {
                                    Title = TitleBox.Text,
                                    BeginDate = BeginDatePicker.SelectedDate.Value,
                                    EndDate = EndDatePicker.SelectedDate.Value,
                                    ChairId = (await authCore.GetAccountByLoginAsync(ChairmanBox.Text)).AccountId,
                                    ConferenceId = UserCredentials.Conference.ConferenceId,
                                    Description = DescriptionBox.Text,
                                    RoomId = ((RoomDTO)RoomBox.SelectedItem).RoomID
                                };

                                if (await core.AddSpecialSessionAsync(specialSession))
                                {
                                    MessageBox.Show("Successfully added special session");
                                    Close();
                                }
                                else MessageBox.Show("Something went wrong while adding special session");
                            }
                            else
                            {
                                var session = new SessionDTO()
                                {
                                    Title = TitleBox.Text,
                                    BeginDate = BeginDatePicker.SelectedDate.Value,
                                    EndDate = EndDatePicker.SelectedDate.Value,
                                    ChairId = (await authCore.GetAccountByLoginAsync(ChairmanBox.Text)).AccountId,
                                    ConferenceId = UserCredentials.Conference.ConferenceId,
                                    Description = DescriptionBox.Text,
                                    RoomId = ((RoomDTO)RoomBox.SelectedItem).RoomID
                                };

                                if (await core.AddSessionAsync(session))
                                {
                                    MessageBox.Show("Successfully added session");
                                    Close();
                                }
                                else MessageBox.Show("Something went wrong while adding session");
                            }
                        }
                        if (currentSession != null)
                        {
                            currentSession.Title = TitleBox.Text;
                            currentSession.BeginDate = BeginDatePicker.SelectedDate.Value;
                            currentSession.EndDate = EndDatePicker.SelectedDate.Value;
                            currentSession.ChairId = (await authCore.GetAccountByLoginAsync(ChairmanBox.Text)).AccountId;
                            currentSession.ConferenceId = UserCredentials.Conference.ConferenceId;
                            currentSession.Description = DescriptionBox.Text;
                            currentSession.RoomId = ((RoomDTO)RoomBox.SelectedItem).RoomID;
                            if (await core.EditSessionAsync(currentSession))
                            {
                                MessageBox.Show("Successfully edited session");
                                Close();
                            }
                            else MessageBox.Show("Something went wrong while editing session");
                        }
                        if (currentSpecialSession != null)
                        {
                            currentSpecialSession.Title = TitleBox.Text;
                            currentSpecialSession.BeginDate = BeginDatePicker.SelectedDate.Value;
                            currentSpecialSession.EndDate = EndDatePicker.SelectedDate.Value;
                            currentSpecialSession.ChairId = (await authCore.GetAccountByLoginAsync(ChairmanBox.Text)).AccountId;
                            currentSpecialSession.ConferenceId = UserCredentials.Conference.ConferenceId;
                            currentSpecialSession.Description = DescriptionBox.Text;
                            currentSpecialSession.RoomId = ((RoomDTO)RoomBox.SelectedItem).RoomID;
                            if (await core.EditSpecialSessionAsync(currentSpecialSession))
                            {
                                MessageBox.Show("Successfully edited special session");
                                Close();
                            }
                            else MessageBox.Show("Something went wrong while editing special session");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some data is overlapping with another session/event or login is invalid");
                        Refresh_Click(null, null);
                    }
                }
                else MessageBox.Show("Form invalid");
            }
            catch
            {
                MessageBox.Show("Something went wrong, try again");
            }
            AddSessionButton.IsEnabled = true;
        }

        private async void BeginDatePicker_SelectedDateChanged(object sender, TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {
            await CheckDate();
            await CheckChairman();
            await LoadAvailableRooms();
        }

        private async Task<bool> CheckRoom()
        {
            if (BuildingBox.SelectedIndex >= 0)
            {
                var roomId = currentSession == null ? (currentSpecialSession == null ? 0 : currentSpecialSession.RoomId) : currentSession.RoomId;
                var rooms = await roomCore.GetAvailableRoomsAsync(((BuildingDTO)BuildingBox.SelectedItem).BuildingID,
                    BeginDatePicker.SelectedDate.Value, EndDatePicker.SelectedDate.Value, roomId);
                return rooms.Exists(room => room.RoomID == ((RoomDTO)RoomBox.SelectedItem).RoomID);
            }
            return false;
        }

        private async void ChairmanBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            await CheckChairman();
        }

        private async void BuildingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await LoadAvailableRooms();
        }
    }
}
