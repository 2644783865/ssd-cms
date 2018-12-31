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
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Accommodation
{
    /// <summary>
    /// Interaction logic for AccomodationConference.xaml
    /// </summary>
    public partial class AccommodationConference : MetroWindow
    {
        private IAccommodationInfoCore accomodationCore;
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
            var accomodation = await accomodationCore.GetAccommodationInfoByConferenceId(UserCredentials.Conference.ConferenceId);

            if (accomodation != null)
            {
                PlaceLabel.Content = accomodation[0].PlaceName;
                DescriptionLabel.Content = accomodation[0].Description;
                CurrencyLabel.Content = accomodation[0].Currency;
                CityLabel.Content = accomodation[0].City;
                CityDescriptionLabel.Content = accomodation[0].CityDesc;
            }
         } 

    }
}
