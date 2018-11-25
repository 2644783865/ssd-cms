using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Conference
{
    /// <summary>
    /// Interaction logic for AddConference.xaml
    /// </summary>
    public partial class AddConference : MetroWindow
    {
        private IConferenceCore core;

        public AddConference()
        {
            InitializeComponent();
            core = new ConferenceCore();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var conference = new ConferenceDTO()
                {
                    Title = TitleBox.Text,
                    Description = DescriptionBox.Text,
                    Place = PlaceBox.Text,
                    BeginDate = BeginDatePicker.SelectedDate.Value,
                    EndDate = EndDatePicker.SelectedDate.Value
                };
                if (await core.AddConferenceAsync(conference))
                {
                    MessageBox.Show("Success");
                    Close();
                }
                else MessageBox.Show("Failure");
            } else MessageBox.Show("Invalid form");
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false: result;
            result = !ValidationHelper.ValidateTextFiled(PlaceBox.Text.Length > 0, PlaceBox) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(BeginDatePicker.SelectedDate.HasValue, BeginDatePicker) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(EndDatePicker.SelectedDate.HasValue && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate >= BeginDatePicker.SelectedDate), EndDatePicker) ? false : result;
            return result;
        }
    }
}
