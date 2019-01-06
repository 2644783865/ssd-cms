using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Accommodation;
using CMS.UI.Windows.Tasks;
using CMS.UI.Windows.Travel;
using CMS.UI.Windows.Emergency;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using CMS.BE.DTO;
using CMS.UI.Windows.Session;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for ConferenceHome.xaml
    /// </summary>
    public partial class ConferenceHome : MetroWindow
    {
        private IAuthenticationCore authCore;
        private IConferenceCore confCore;
        private IEventCore eventCore;
        private ISessionCore sessionCore;

        public ConferenceHome()
        {
            InitializeComponent();
            authCore = new AuthenticationCore();
            confCore = new ConferenceCore();
            eventCore = new EventCore();
            sessionCore = new SessionCore();
            WindowHelper.WindowSettings(this, UserLabel, ConferenceLabel);
            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                InitializeLabels();
                LoadEvents();
                LoadSessions();
                LoadSpecialSessions();
                SetVisibility();
            }
            catch
            {
                MessageBox.Show("Something went wrong, please try again");
            }
        }

        private void SetVisibility()
        {
            TaskSchedule.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceStaffMember)) != null ? Visibility.Visible : Visibility.Collapsed;
            TaskScheduleLabel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceStaffMember)) != null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void InitializeLabels()
        {
            TitleLabel.Content = UserCredentials.Conference.Title;
            DatesLabel.Content = $"{UserCredentials.Conference.BeginDate.ToShortDateString()} - {UserCredentials.Conference.EndDate.ToShortDateString()}";
            PlaceLabel.Content = UserCredentials.Conference.Place;
            DescriptionBox.Text = UserCredentials.Conference.Description;
        }

        private async void LoadEvents()
        {
            EventList.ClearValue(ItemsControl.ItemsSourceProperty);
            EventList.DisplayMemberPath = "EventDesc";
            EventList.SelectedValuePath = "EventId";
            EventList.ItemsSource = await eventCore.GetEventsAsync(UserCredentials.Conference.ConferenceId);
        }

        private async void LoadSessions()
        {
            SessionList.ClearValue(ItemsControl.ItemsSourceProperty);
            SessionList.DisplayMemberPath = "SessionDesc";
            SessionList.SelectedValuePath = "SessionId";
            SessionList.ItemsSource = await sessionCore.GetSessionsAsync(UserCredentials.Conference.ConferenceId);
        }

        private async void LoadSpecialSessions()
        {
            SpecialSessionList.ClearValue(ItemsControl.ItemsSourceProperty);
            SpecialSessionList.DisplayMemberPath = "SpecialSessionDesc";
            SpecialSessionList.SelectedValuePath = "SpecialSessionId";
            SpecialSessionList.ItemsSource = await sessionCore.GetSpecialSessionsAsync(UserCredentials.Conference.ConferenceId);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToUserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UserPanel newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }

        private async void DownloadProgram_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            DownloadProgram.IsEnabled = false;
            try
            {
                var document = await confCore.GetConferenceProgramAsync(UserCredentials.Conference.ConferenceId);
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FileName = $"{UserCredentials.Conference.Title} Program.pdf"
                };

                if ((bool)saveFileDialog.ShowDialog())
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                    {
                        writer.Write(document);
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot override the file. The file may be opened.");
            }
            catch
            {
                MessageBox.Show("Error downloading conference program");
            }
            DownloadProgram.IsEnabled = true;
            ProgressSpin.IsActive = false;
        }

        private void TaskSchedule_Click(object sender, RoutedEventArgs e)
        {
            ViewTaskSchedule newWindow = new ViewTaskSchedule(true);
            newWindow.ShowDialog();
        }

        private void AccomButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationConference newWindow = new AccommodationConference();
            newWindow.ShowDialog();
        }

        private void TravelButton_Click(object sender, RoutedEventArgs e)
        {
            TravelConference newWindow = new TravelConference();
            newWindow.ShowDialog();
        }

        private void EmergButton_Click(object sender, RoutedEventArgs e)
        {
            EmergencyInfoOnlyRead newWindow = new EmergencyInfoOnlyRead();
            newWindow.ShowDialog();
        }

        private void SessionList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var session = (SessionDTO)SessionList.SelectedItem;
            SessionDetails newWindow = new SessionDetails(session, null);
            newWindow.ShowDialog();
        }

        private void SpecialSessionList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var specialSession = (SpecialSessionDTO)SpecialSessionList.SelectedItem;
            SessionDetails newWindow = new SessionDetails(null, specialSession);
            newWindow.ShowDialog();
        }

        private void EventList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
