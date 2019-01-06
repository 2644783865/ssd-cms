using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Account;
using CMS.UI.Windows.Messages;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : MetroWindow
    {
        private IAuthenticationCore core;
        private IAuthorCore authorCore;
        private IMessageCore messageCore;
        Timer messageTimer;
        public UserPanel()
        {
            InitializeComponent();
            core = new AuthenticationCore();
            authorCore = new AuthorCore();
            messageCore = new MessageCore();
            WindowHelper.WindowSettings(this, UserLabel);
            InitializeData();
            SetMessageTimer();
            
        }

        private void SetMessageTimer()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(30);

            messageTimer = new Timer((e) =>
            {
               Dispatcher.Invoke(() => CheckNewMessages());
            }, null, startTimeSpan, periodTimeSpan);
        }

        private async void CheckNewMessages()
        {
            var numberOfMessages = await messageCore.HasNewMessages();
            if (numberOfMessages > 0) SetNewMessageIcon(numberOfMessages);
            else SetStandardMessageIcon();
        }

        private void SetStandardMessageIcon()
        {
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var packIcon = new PackIconFontAwesome()
            {
                Kind = PackIconFontAwesomeKind.EnvelopeRegular,
                Margin = new Thickness(0, 0, 0, 0),
                Width = 50,
                Height = 50,
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(packIcon);
            
            MessageButton.Content = stackPanel;
        }

        private void SetNewMessageIcon(int numberOfMessages)
        {
            var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var packIcon = new PackIconFontAwesome()
            {
                Kind = PackIconFontAwesomeKind.EnvelopeRegular,
                Margin = new Thickness(0, -10, 0, 0),
                Width = 45,
                Height = 45,
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(packIcon);
            if (numberOfMessages < 10)
            {
                var label = new Label()
                {
                    Content = numberOfMessages,
                    Margin = new Thickness(-17, 20, 0, -5),
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Background = Brushes.Red,
                    FontSize = 15,
                    Height = 30,
                    Width = 20
                };
                stackPanel.Children.Add(label);
            }
            else
            {
                var label = new Label()
                {
                    Content = "9+",
                    Margin = new Thickness(-17, 15, 0, 0),
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Background = Brushes.Red,
                    FontSize = 15,
                    Height = 30,
                    Width = 30
                };
                stackPanel.Children.Add(label);
            }
            MessageButton.Content = stackPanel;
        }

        private async void InitializeData()
        {
            UserCredentials.Author = await authorCore.GetAuthorByAccountIdAsync(UserCredentials.Account.AccountId);
            ProgressSpin.IsActive = true;
            await FillConferenceList();
            FillUserData();
            SetButtonVisibility(false);
            ProgressSpin.IsActive = false;
        }

        private void SetButtonVisibility(bool isManager)
        {
            GoToAuthorPanelButton.Visibility = UserCredentials.Author != null ? Visibility.Visible : Visibility.Collapsed;
            GoToManagerPanelButton.Visibility = isManager ? Visibility.Visible : Visibility.Collapsed;
        }

        private async Task FillConferenceList()
        {
            ConferenceList.ClearValue(ItemsControl.ItemsSourceProperty);
            await core.LoadConferencesAsync();
            ConferenceList.DisplayMemberPath = "ConferenceDesc";
            ConferenceList.SelectedValuePath = "ConferenceId";
            ConferenceList.ItemsSource = UserCredentials.Conferences;
        }

        private void FillUserData()
        {
            IdLabel.Content = "Id: " + UserCredentials.Account.AccountId;
            NameLabel.Content = "Name: " + UserCredentials.Account.Name;
            LoginLabel.Content = "Login: " + UserCredentials.Account.Login;
            EmailLabel.Content = "Email: " + UserCredentials.Account.Email;
            PhoneLabel.Content = "Phone: " + UserCredentials.Account.PhoneNumber;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private async void GoToConferenceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                ConferenceHome newWindow = new ConferenceHome();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private async void GoToManagerPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                ManagerPanel newWindow = new ManagerPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }

        private async void GoToAuthorPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                UserCredentials.Conference = (ConferenceDTO)ConferenceList.SelectedItem;
                await core.LoadRolesAsync();
                AuthorPanel newWindow = new AuthorPanel();
                newWindow.Show();
                Close();
            }
            else MessageBox.Show("Choose conference");
        }


        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowHelper.CheckOtherWindows())
            {
                ChangePassword newChangePasswordWindow = new ChangePassword();
                newChangePasswordWindow.Show();
                Close();
            }
        }

        private async void ConferenceList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ConferenceList.SelectedIndex >= 0)
            {
                var result = await core.CheckIsManager(((ConferenceDTO)ConferenceList.SelectedItem).ConferenceId);
                SetButtonVisibility(result);
            }
        }

        private void MessageButton_Click(object sender, RoutedEventArgs e)
        {
            MessageMainWindow newMainMessageWindow = new MessageMainWindow();
            newMainMessageWindow.Show();
        }
    }
}
