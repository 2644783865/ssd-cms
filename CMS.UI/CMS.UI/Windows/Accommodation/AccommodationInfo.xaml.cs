using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;


namespace CMS.UI.Windows.Accommodation
{
    /// <summary>
    /// Interaction logic for AccommodationInfo.xaml
    /// </summary>
    public partial class AccommodationInfo : MetroWindow
    {
        private AccommodationInfoDTO currentAccommodation;

        public AccommodationInfo(AccommodationInfoDTO accommodation)
        {
            InitializeComponent();
            currentAccommodation = accommodation;
            if (accommodation != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            currentAccommodation.PlaceName= PlaceNameBox.Text;
            currentAccommodation.Description= DescriptionBox.Text;
            currentAccommodation.Currency = CurrencyBox.Text;
            currentAccommodation.City = CityBox.Text;
            currentAccommodation.CityDesc = CityDescBox.Text;

        }
    }
}
