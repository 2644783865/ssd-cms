using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

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

        private async void InitializeData()
        {
            authCore.LoadRolesAsync();
            InitializeLabels();
            await LoadEvents();
        }

        private void InitializeLabels()
        {
            TitleLabel.Content = UserCredentials.Conference.Title;
            DatesLabel.Content = $"{UserCredentials.Conference.BeginDate.ToShortDateString()} - {UserCredentials.Conference.EndDate.ToShortDateString()}";
            PlaceLabel.Content = UserCredentials.Conference.Place;
            DescriptionBox.Text = UserCredentials.Conference.Description;
        }

        private async Task LoadEvents()
        {
            EventList.Items.Clear();
            EventList.DisplayMemberPath = "Title";
            EventList.SelectedValuePath = "EventId";
            EventList.ItemsSource = await eventCore.GetEventsAsync(UserCredentials.Conference.ConferenceId);
        }

        private async Task LoadSessions()
        {

        }

        private async Task LoadSpecialSessions()
        {

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

        private void GoToManagerPanelButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerPanel newWindow = new ManagerPanel();
            newWindow.Show();
            Close();
        }

        private async void DownloadProgram_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            DownloadProgram.IsEnabled = false;
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
            DownloadProgram.IsEnabled = true;
            ProgressSpin.IsActive = false;
        }
    }
}
