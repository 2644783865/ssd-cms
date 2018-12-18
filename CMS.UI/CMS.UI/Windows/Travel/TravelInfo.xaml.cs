using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;


namespace CMS.UI.Windows.Travel
{
    /// <summary>
    /// Interaction logic for TravelInfo.xaml
    /// </summary>
    public partial class TravelInfo : MetroWindow
    {
        private TravelInfoDTO currenTravel;

        public TravelInfo(TravelInfoDTO travel)
        {
            InitializeComponent();
            currenTravel = travel;
            if (travel != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            int AirportRoadTime = System.Convert.ToInt32(AirportRoadTimeBox.Text);
            int RailwayRoadTime = System.Convert.ToInt32(RailwayRoadTimeBox.Text);


            currenTravel.Title = TitleBox.Text;
            currenTravel.AirportRoad = AirportRoadBox.Text;
            currenTravel.AirportRoadTime= AirportRoadTime;
            currenTravel.RailwayRoad= RailwayRoadBox.Text;
            currenTravel.RailwayRoadTime = RailwayRoadTime;
            currenTravel.TaxiNum = TaxiNumBox.Text;

        }
    }
}


