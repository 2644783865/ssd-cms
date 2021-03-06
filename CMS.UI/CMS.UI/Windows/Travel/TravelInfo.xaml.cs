﻿using MahApps.Metro.Controls;
using System.Windows;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;

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
            WindowHelper.SmallWindowSettings(this);
            currenTravel = travel;
            if (travel != null)
            {
                InitializeEditFields();
            }
            else
            {
                this.Title = "Add Travel";
                SaveButton.Content = "Add";
            }
        }

        private void InitializeEditFields()
        {
            TitleBox.Text = currenTravel.Title;
            AirportRoadBox.Text = currenTravel.AirportRoad;
            AirportRoadTimeBox.Text = System.Convert.ToString(currenTravel.AirportRoadTime);
            RailwayRoadBox.Text = currenTravel.RailwayRoad;
            RailwayRoadTimeBox.Text = System.Convert.ToString(currenTravel.RailwayRoadTime);
            TaxiNumBox.Text = currenTravel.TaxiNum;
            this.Title = "Edit Travel";
            SaveButton.Content = "Save";
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (ITravelInfoCore core = new TravelInfoCore())
                {
                    int AirportRoadTime = System.Convert.ToInt32(AirportRoadTimeBox.Text);
                    int RailwayRoadTime = System.Convert.ToInt32(RailwayRoadTimeBox.Text);
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
                            TaxiNum= TaxiNumBox.Text,
                            ConferenceId = UserCredentials.Conference.ConferenceId
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
            result = !ValidationHelper.ValidateTextFiled(RailwayRoadTimeBox.Text.Length > 0 && int.TryParse(RailwayRoadTimeBox.Text, out _), RailwayRoadTimeBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(AirportRoadTimeBox.Text.Length > 0 && int.TryParse(AirportRoadTimeBox.Text, out _), AirportRoadTimeBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(TaxiNumBox.Text.Length > 0, TaxiNumBox) ? false : result;
            return result;
        }
    }
}


