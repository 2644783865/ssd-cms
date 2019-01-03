using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Accommodation;
using CMS.UI.Windows.Account;
using CMS.UI.Windows.Articles;
using CMS.UI.Windows.Author;
using CMS.UI.Windows.Award;
using CMS.UI.Windows.Emergency;
using CMS.UI.Windows.Event;
using CMS.UI.Windows.Tasks;
using CMS.UI.Windows.Travel;
using CMS.UI.Windows.WelcomePack;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for ManagerPanel.xaml
    /// </summary>
    public partial class ManagerPanel : MetroWindow
    {
        private IAuthenticationCore authCore;
        private IConferenceCore confCore;
        private IEventCore eventCore;
        private ISessionCore sessionCore;
        public ManagerPanel()
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

        private void SetVisibility()
        {
            var test = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceManager) || r.Name.Equals(Properties.RoleResources.ConferenceChair));
            if (test == null)
            {
                ManageTasks.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.ConferenceStaffManager)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageAccount.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.HRAdministrator)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageAuthor.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.HRAdministrator)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageEvent.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageAward.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.AwardsCoordinator)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageSessions.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageAccom.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.InformationStaff)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageEmergency.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.InformationStaff)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageTravel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.InformationStaff)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageWelcomePack.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.WelcomePackStaff)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageArticlesEditor.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null ? Visibility.Visible : Visibility.Collapsed;
                ManageArticlesEditorLabel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null ? Visibility.Visible : Visibility.Collapsed;
            }

            DownloadSchedule.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.SessionChair)) != null ? Visibility.Visible : Visibility.Collapsed;
            DownloadScheduleLabel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.SessionChair)) != null ? Visibility.Visible : Visibility.Collapsed;
            DownloadICal.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.SessionChair)) != null ? Visibility.Visible : Visibility.Collapsed;
            DownloadICalLabel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.SessionChair)) != null ? Visibility.Visible : Visibility.Collapsed;
            ReviewArticles.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Reviewer)) != null ? Visibility.Visible : Visibility.Collapsed;
            ReviewArticlesLabel.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Reviewer)) != null ? Visibility.Visible : Visibility.Collapsed;
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

        private void GoToConferenceHomeButton_Click(object sender, RoutedEventArgs e)
        {
            ConferenceHome newWindow = new ConferenceHome();
            newWindow.Show();
            Close();
        }

        private void ManageAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ManageAccount newWindow = new ManageAccount();
            newWindow.ShowDialog();
        }

        private void ManageAuthor_Click(object sender, RoutedEventArgs e)
        {
            ManageAuthor newWindow = new ManageAuthor();
            newWindow.ShowDialog();
        }

        private void ManageEvent_Click(object sender, RoutedEventArgs e)
        {
            AddEditEvent newWindow = new AddEditEvent();
            newWindow.ShowDialog();
        }

        private void ManageAward_Click(object sender, RoutedEventArgs e)
        {
            ManageAwards newWindow = new ManageAwards();
            newWindow.ShowDialog();
        }

        private void ManageTasks_Click(object sender, RoutedEventArgs e)
        {
            ManageTasksWindow newWindow = new ManageTasksWindow();
            newWindow.ShowDialog();
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

        private async void DownloadSchedule_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            DownloadSchedule.IsEnabled = false;
            try
            {
                var document = await confCore.GetConferenceScheduleAsync(UserCredentials.Account.AccountId, UserCredentials.Conference.ConferenceId);
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FileName = $"{UserCredentials.Conference.Title} Schedule for {UserCredentials.Account.Name}.pdf"
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
                MessageBox.Show("Error downloading schedule");
            }
            DownloadSchedule.IsEnabled = true;
            ProgressSpin.IsActive = false;
        }

        private void ManageSessions_Click(object sender, RoutedEventArgs e)
        {
            Session.Session newWindow = new Session.Session();
            newWindow.ShowDialog();
        }

        private void ManageArticlesEditor_Click(object sender, RoutedEventArgs e)
        {
            ArticlePanel newWindow = new ArticlePanel();
            newWindow.ShowDialog();
        }

        private void MetroWindow_Activated(object sender, System.EventArgs e)
        {
            InitializeData();
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

        private void ManageEmergency_Click(object sender, RoutedEventArgs e)
        {
            EmergencyInfo newWindow = new EmergencyInfo();
            newWindow.ShowDialog();
        }

        private void ManageAccom_Click(object sender, RoutedEventArgs e)
        {
            AccommodationManage newWindow = new AccommodationManage();
            newWindow.ShowDialog();
        }

        private void ManageTravel_Click(object sender, RoutedEventArgs e)
        {
            TravelManage newWindow = new TravelManage();
            newWindow.ShowDialog();
        }

        private void ManageWelcomePack_Click(object sender, RoutedEventArgs e)
        {
            GuestsList newWindow = new GuestsList();
            newWindow.ShowDialog();
        }
    }
}
