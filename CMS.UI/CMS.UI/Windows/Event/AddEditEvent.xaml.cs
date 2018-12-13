using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Event
{
    /// <summary>
    /// Lógica de interacción para AddEditEvent.xaml
    /// </summary>
    public partial class AddEditEvent : MetroWindow
    {
        public AddEditEvent()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(BeginDatePicker.SelectedDate.HasValue, BeginDatePicker) ? false : result;
            result = !ValidationHelper.ValidateDatePicker(EndDatePicker.SelectedDate.HasValue && (BeginDatePicker.SelectedDate.HasValue
                && EndDatePicker.SelectedDate >= BeginDatePicker.SelectedDate), EndDatePicker) ? false : result;
            return result;
        }
    }
}
