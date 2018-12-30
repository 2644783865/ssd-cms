﻿using MahApps.Metro.Controls;
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
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;


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
            this.Title = "Add Accommodation";
               
        }

        private void InitializeEditFields()
        {

            currentAccommodation.PlaceName= PlaceNameBox.Text;
            currentAccommodation.Description= DescriptionBox.Text;
            currentAccommodation.Currency = CurrencyBox.Text;
            currentAccommodation.City = CityBox.Text;
            currentAccommodation.CityDesc = CityDescBox.Text;
            this.Title = "Edit Accommodation";
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (IAccommodationInfoCore core = new AccommodationInfoCore())
                {
                    bool result = false;

                    if (currentAccommodation == null)
                    {
                        var accommodationModel = new AccommodationInfoDTO()
                        {
                            PlaceName = PlaceNameBox.Text,
                            Description = DescriptionBox.Text,
                            Currency = CurrencyBox.Text,
                            City = CityBox.Text,
                            CityDesc = CityDescBox.Text
                        };
                        result = await core.AddAccommodationInfoAsync(accommodationModel);
                    }
                    else
                    {
                        currentAccommodation.PlaceName= PlaceNameBox.Text;
                        currentAccommodation.Description= DescriptionBox.Text;
                        currentAccommodation.Currency = CurrencyBox.Text;
                        currentAccommodation.City= CityBox.Text;
                        currentAccommodation.CityDesc = CityDescBox.Text;

                        result = await core.EditAccommodationInfoAsync(currentAccommodation);
          
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
            result = !ValidationHelper.ValidateTextFiled(PlaceNameBox.Text.Length > 0, PlaceNameBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(CityBox.Text.Length > 0, CityBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(CityDescBox.Text.Length > 0, CityDescBox) ? false : result;
            return result;
        }
    }
}
