using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Session : MetroWindow
    {
        private ISessionCore core;
        public Session()
        {
            InitializeComponent();
            core = new SessionCore();
            LoadData();
        }

        private async void LoadData()
        {
            SessionList.ClearValue(ItemsControl.ItemsSourceProperty);
            SessionList.ItemsSource = await core.GetSessionsAsync(UserCredentials.Conference.ConferenceId);
            SpecialSessionList.ClearValue(ItemsControl.ItemsSourceProperty);
            SpecialSessionList.ItemsSource = await core.GetSpecialSessionsAsync(UserCredentials.Conference.ConferenceId);
        }

        private void AddSession_Click(object sender, RoutedEventArgs e)
        {
            AddEditSession newWindow = new AddEditSession(null, null);
            newWindow.ShowDialog();
        }

        private void EditSession_Click(object sender, RoutedEventArgs e)
        {
            if (SessionList.SelectedIndex >= 0)
            {
                PresentationSession newWindow = new PresentationSession((SessionDTO)SessionList.SelectedItem);
                newWindow.ShowDialog();
            }
            else MessageBox.Show("Select session first");
        }

        private async void DeleteSession_Click(object sender, RoutedEventArgs e)
        {
            if (SessionList.SelectedIndex >= 0)
            {
                if (await core.DeleteSessionAsync(((SessionDTO)SessionList.SelectedItem).SessionId))
                {
                    MessageBox.Show("Successfully delete session");
                }
                else MessageBox.Show("Something went wrong while deleting session");
            }
            else MessageBox.Show("Select session first");
        }

        private void EditSpecialSession_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialSessionList.SelectedIndex >= 0)
            {
                AddEditSession newWindow = new AddEditSession(null, (SpecialSessionDTO)SpecialSessionList.SelectedItem);
                newWindow.ShowDialog();
            }
            else MessageBox.Show("Select special session first");
        }

        private async void DeleteSpecialSession_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialSessionList.SelectedIndex >= 0)
            {
                if (await core.DeleteSpecialSessionAsync(((SpecialSessionDTO)SpecialSessionList.SelectedItem).SpecialSessionId))
                {
                    MessageBox.Show("Successfully delete special session");
                }
                else MessageBox.Show("Something went wrong while deleting special session");
            }
            else MessageBox.Show("Select special session first");
        }

        private void MetroWindow_Activated(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SessionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditSession_Click(null, null);
        }

        private void SpecialSessionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditSpecialSession_Click(null, null);
        }
    }
}
