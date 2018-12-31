using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;

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
            accomodationCore = new AccommodationInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadAccomodation();
        }

        private async Task LoadAccomodation()
        {
            var accomodation = await accomodationCore.GetAccommodationInfoByConferenceId(UserCredentials.Conference.ConferenceId);
            AccomodationDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            AccomodationDataGrid.ItemsSource = accomodation;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AccommodationInfo newAddAccommodationWindow = new AccommodationInfo(null);
            newAddAccommodationWindow.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            // var account = DATAGRID INFO
            AccommodationInfo newAddAccommodationWindow = new AccommodationInfo(null /*accommodation*/);
            newAddAccommodationWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
