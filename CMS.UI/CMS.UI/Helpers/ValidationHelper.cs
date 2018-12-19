using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace CMS.UI.Helpers
{
    public class ValidationHelper
    {
        public static bool ValidateTextFiled(bool result, TextBox textFiled)
        {
            textFiled.BorderBrush = result ? BrushSettings.NormalBrush : BrushSettings.ErrorBrush;
            return result;
        }

        public static bool ValidateDatePicker(bool result, DatePicker datePicker)
        {
            datePicker.BorderBrush = result ? BrushSettings.NormalBrush : BrushSettings.ErrorBrush;
            return result;
        }

        public static bool ValidateDateTimePicker(bool result, Border errorBorder)
        {
            errorBorder.BorderBrush = result ? BrushSettings.NormalBrush : BrushSettings.ErrorBrush;
            return result;
        }

        public static bool ValidatePasswordBox(bool result, PasswordBox passwordBox)
        {
            passwordBox.BorderBrush = result ? BrushSettings.NormalBrush : BrushSettings.ErrorBrush;
            return result;
        }
    }
}
