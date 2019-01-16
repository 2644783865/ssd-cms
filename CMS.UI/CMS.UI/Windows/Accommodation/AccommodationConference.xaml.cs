using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.Core.Core;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.Accommodation
{
    /// <summary>
    /// Interaction logic for AccomodationConference.xaml
    /// </summary>
    public partial class AccommodationConference : MetroWindow
    {
        private IAccommodationInfoCore accomodationCore;
        private int index = 0;
        private int size;

        public AccommodationConference()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            accomodationCore = new AccommodationInfoCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadLabels();
        }

        private async Task LoadLabels()
        {
            var accomodation = await accomodationCore.GetAccommodationInfoByConferenceIdAsync(UserCredentials.Conference.ConferenceId);
            size = accomodation.Count;

            if (accomodation != null)
            {
                Index.Content = "#" + (index + 1);
                
                PlaceLabel.Text = accomodation[index].PlaceName;
                DescriptionLabel.Text = accomodation[index].Description;
                CurrencyLabel.Text = accomodation[index].Currency;
                CityLabel.Text = accomodation[index].City;
                CityDescriptionLabel.Text = accomodation[index].CityDesc;
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
