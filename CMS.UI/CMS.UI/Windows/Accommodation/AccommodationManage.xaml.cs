using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using System.Windows.Input;
using CMS.BE.DTO;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.Accommodation
{
    /// <summary>
    /// Interaction logic for AccomodationManage.xaml
    /// </summary>
    public partial class AccommodationManage : MetroWindow
    {
        private IAccommodationInfoCore accomodationCore;
        public AccommodationManage()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            accomodationCore = new AccommodationInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadAccomodation();
        }

        private async Task LoadAccomodation()
        {
            var accomodation = await accomodationCore.GetAccommodationInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            AccomodationDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            AccomodationDataGrid.ItemsSource = accomodation;
        }

        private async void Button_Add(object sender, RoutedEventArgs e)
        {
            if (AccomodationDataGrid.Items.Count < 5)
            {
                AccommodationInfo newAddAccommodationWindow = new AccommodationInfo(null);
                newAddAccommodationWindow.ShowDialog();
                await LoadAccomodation();
            }
            else MessageBox.Show("There can be only 5 accommodations");
        }


        private async void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (AccomodationDataGrid.SelectedIndex >= 0)
            {
                var result = await accomodationCore.DeleteAccommodationInfoAsync(((AccommodationInfoDTO)AccomodationDataGrid.SelectedItem).AccommodationInfoId);
                if (result)
                {
                    MessageBox.Show("Successfully deleted accomodation");
                    await LoadAccomodation();
                }
                else MessageBox.Show("Error occured while deleting accomodation");
            }
            else MessageBox.Show("Choose accomodation first");
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditAccomodation_Click(sender, e);
        }
 
        private async void EditAccomodation_Click(object sender, RoutedEventArgs e)
        {
            if (AccomodationDataGrid.SelectedIndex >= 0)
            {
                var accomodation = await accomodationCore.GetAccommodationInfoByIdAsync(((AccommodationInfoDTO)AccomodationDataGrid.SelectedItem).AccommodationInfoId);
                AccommodationInfo newAccommodationInfoWindow = new AccommodationInfo(accomodation);
                newAccommodationInfoWindow.ShowDialog();
                await LoadAccomodation();
            }
            else MessageBox.Show("Choose accomodation first");
        }
    }
}
