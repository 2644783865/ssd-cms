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
            this.Title = "Add Travel";

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
            this.Title = "Edit Travel";

        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {

            int AirportRoadTime = System.Convert.ToInt32(AirportRoadTimeBox.Text);
            int RailwayRoadTime = System.Convert.ToInt32(RailwayRoadTimeBox.Text);

            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (ITravelInfoCore core = new TravelInfoCore())
                {
                    bool result = false;

                    if (currenTravel == null)
                    {
                        var travelModel= new TravelInfoDTO()
                        {
                            Title = TitleBox.Text,
                            AirportRoad = AirportRoadBox.Text,
                            AirportRoadTime = AirportRoadTime,
                            RailwayRoad = RailwayRoadBox.Text,
                            RailwayRoadTime = RailwayRoadTime,
                            TaxiNum= TaxiNumBox.Text
                        };
                        result = await core.AddTravelAsync(travelModel);
                    }
                    else
                    {
                        currenTravel.Title = TitleBox.Text;
                        currenTravel.AirportRoad= AirportRoadBox.Text;
                        currenTravel.AirportRoadTime= AirportRoadTime;
                        currenTravel.RailwayRoad= RailwayRoadBox.Text;
                        currenTravel.RailwayRoadTime= RailwayRoadTime;
                        currenTravel.TaxiNum= TaxiNumBox.Text;


                        result = await core.EditTravelAsync(currenTravel);
                    }

                    if (result)
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failure");
                    }
                }
            else MessageBox.Show("Form invalid");
            ProgressSpin.IsActive = false;
        }
    

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(AirportRoadBox.Text.Length > 0, AirportRoadBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(RailwayRoadBox.Text.Length > 0, RailwayRoadBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(TaxiNumBox.Text.Length > 0, TaxiNumBox) ? false : result;
            return result;
        }
    }
}


