using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using System.Windows.Input;
using CMS.BE.DTO;

namespace CMS.UI.Windows.Travel
{
    /// <summary>
    /// Interaction logic for TravelManage.xaml
    /// </summary>
    public partial class TravelManage : MetroWindow
    {
        private ITravelInfoCore travelCore;
        public TravelManage()
        {
            InitializeComponent();
            travelCore = new TravelInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadTravel();
        }

        private async Task LoadTravel()
        {
            var travel = await travelCore.GetTravelInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            TravelDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            TravelDataGrid.ItemsSource = travel;
        }

        private async void Button_Add(object sender, RoutedEventArgs e)
        {
            TravelInfo newAddTravelWindow = new TravelInfo(null);
            newAddTravelWindow.ShowDialog();
            await LoadTravel();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TravelDataGrid.SelectedIndex >= 0)
            {
                var travel = await travelCore.DeleteTravelAsync(((TravelInfoDTO)TravelDataGrid.SelectedItem).TravelInfoId);
                if (travel)
                {
                    MessageBox.Show("Successfully deleted travel");
                    await LoadTravel();
                }
                else MessageBox.Show("Error occured while deleting travel");
            }
            else MessageBox.Show("Choose travel first");
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditTravel_Click(sender, e);
        }

        private async void EditTravel_Click(object sender, RoutedEventArgs e)
        {
            if (TravelDataGrid.SelectedIndex >= 0)
            {
                var travel = await travelCore.GetTravelByIdAsync(((TravelInfoDTO)TravelDataGrid.SelectedItem).TravelInfoId);
                TravelInfo newTravelInfoWindow = new TravelInfo(travel);
                newTravelInfoWindow.ShowDialog();
                await LoadTravel();
            }
            else MessageBox.Show("Choose travel first");
        }
    }
}
