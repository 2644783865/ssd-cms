using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using CMS.Core.Interfaces;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;

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
                
                PlaceLabel.Content = accomodation[index].PlaceName;
                DescriptionLabel.Content = accomodation[index].Description;
                CurrencyLabel.Content = accomodation[index].Currency;
                CityLabel.Content = accomodation[index].City;
                CityDescriptionLabel.Content = accomodation[index].CityDesc;
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
