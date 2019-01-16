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
    public partial class AddEditConference : MetroWindow
    {
        private IConferenceCore core;
        private ConferenceDTO currentConference;

        public AddEditConference(ConferenceDTO conference)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            core = new ConferenceCore();
            currentConference = conference;
            if (conference != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            TitleBox.Text = currentConference.Title;
            DescriptionBox.Text = currentConference.Description;
            PlaceBox.Text = currentConference.Place;
            BeginDatePicker.SelectedDate = currentConference.BeginDate;
            EndDatePicker.SelectedDate = currentConference.EndDate;
            SubmitButton.Content = "Save";
            this.Title = "Edit Conference";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                bool result = false;
                if (currentConference == null)
                {
                    var conference = new ConferenceDTO()
                    {
                        Title = TitleBox.Text,
                        Description = DescriptionBox.Text,
                        Place = PlaceBox.Text,
                        BeginDate = BeginDatePicker.SelectedDate.Value,
                        EndDate = EndDatePicker.SelectedDate.Value
                    };
                    result = await core.AddConferenceAsync(conference);
                }
                else
                {
                    currentConference.Title = TitleBox.Text;
                    currentConference.Description = DescriptionBox.Text;
                    currentConference.Place = PlaceBox.Text;
                    currentConference.BeginDate = BeginDatePicker.SelectedDate.Value;
                    currentConference.EndDate = EndDatePicker.SelectedDate.Value;

                    result = await core.EditConferenceAsync(currentConference);
                }
                if (result)
                {
                    MessageBox.Show("Success");
                    Close();
                }
                else MessageBox.Show("Failure");
            }
            else MessageBox.Show("Invalid form");
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(PlaceBox.Text.Length > 0, PlaceBox) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(BeginDatePicker.SelectedDate.HasValue, BeginDatePicker) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(EndDatePicker.SelectedDate.HasValue && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate.Value >= BeginDatePicker.SelectedDate.Value), EndDatePicker) ? false : result;
            return result;
        }
    }
}
