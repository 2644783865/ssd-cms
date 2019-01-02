using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;

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

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            TravelInfo newAddTravelWindow = new TravelInfo(null);
            newAddTravelWindow.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            // var travel = DATAGRID INFO
            TravelInfo newAddTravelWindow = new TravelInfo(null/*travel*/);
            newAddTravelWindow.ShowDialog();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
