﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.BE.DTO;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.WelcomePack
{
    /// <summary>
    /// Interaction logic for GuestsList.xaml
    /// </summary>
    public partial class GuestsList : MetroWindow
    {
        private IWelcomePackCore welcomePackCore;
        public GuestsList()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            welcomePackCore = new WelcomePackCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadGuests();
        }

        private async Task LoadGuests()
        {
            var guestsList = await welcomePackCore.GetGuestsByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            GuestsDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            GuestsDataGrid.ItemsSource = guestsList;
        }

        private async void Button_Add(object sender, RoutedEventArgs e)
        {
            GuestAdd newWindow = new GuestAdd();
            newWindow.ShowDialog();
            await LoadGuests();
        }

        private async void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (GuestsDataGrid.SelectedIndex >= 0)
            {
                var result = await welcomePackCore.DeleteWelcomePackReceiverAsync(((WelcomePackReceiverDTO)GuestsDataGrid.SelectedItem).WelcomePackReceiverId);
                if (result)
                {
                    MessageBox.Show("Successfully deleted guest");
                    await LoadGuests();
                }
                else MessageBox.Show("Error occured while deleting guest");
            }
            else MessageBox.Show("Choose guest first");
        }

        // Not finished...
        private async void AddGift_Click(object sender, RoutedEventArgs e)
        {
            if (GuestsDataGrid.SelectedIndex >= 0)
            {
                var guestToEdit = (WelcomePackReceiverDTO)GuestsDataGrid.SelectedItem;
                guestToEdit.GetGift = !guestToEdit.GetGift;
                await welcomePackCore.EditWelcomePackReceiverAsync(guestToEdit);
                await LoadGuests();
            }
            else MessageBox.Show("Choose guest first");
        }
    }
}
