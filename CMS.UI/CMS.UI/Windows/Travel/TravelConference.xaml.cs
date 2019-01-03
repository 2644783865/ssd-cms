using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;

namespace CMS.UI.Windows.Travel
{
    /// <summary>
    /// Interaction logic for TravelConference.xaml
    /// </summary>
    public partial class TravelConference : MetroWindow
    {
        private ITravelInfoCore travelCore;
        private int index = 0;
        private int size;

        public TravelConference()
        {
            InitializeComponent();
            travelCore = new TravelInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadLabels();
        }

        private async Task LoadLabels()
        {
            var travel = await travelCore.GetTravelInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            size = travel.Count;

            if (travel != null)
            {
                Index.Content = "#" + (index + 1);

                TitleLabel.Content = travel[index].Title;
                AirportLabel.Content = travel[index].AirportRoad;
                AirportTimeLabel.Content = travel[index].AirportRoadTime;
                RailwayLabel.Content = travel[index].RailwayRoad;
                RailwayTimeLabel.Content = travel[index].RailwayRoadTime;
                TaxiLabel.Content = travel[index].TaxiNum;
            }
        }

        private async void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index -= 1;
                await LoadLabels();
            }
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < size - 1)
            {
                index += 1;
                await LoadLabels();
            }
        }
    }
}
