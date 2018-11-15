using CMS.BE.Models.Authentication;
using CMS.Core.Core;
using CMS.Core.Core.Authentication;
using CMS.Core.Interfaces.Authentication;
using CMS.UI.Helpers;
using CMS.UI.Windows.Home;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CMS.UI.Windows.Account
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : MetroWindow
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void ChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            WrongPassLabel.Visibility = Visibility.Hidden;
            if (ValidateForm())
            {
                using (IAuthenticationCore core = new AuthenticationCore())
                {
                    var passwordModel = new ChangePasswordModel()
                    {
                        Login = UserCredentials.Username,
                        Password = OldPassBox.Password,
                        NewPassword = NewPasswordBox.Password
                    };

                    if (await core.ChangePasswordAsync(passwordModel))
                    {
                        Close();
                    }
                    else WrongPassLabel.Visibility = Visibility.Visible;
                }
            }
            else MessageBox.Show("Invalid form");
            ProgressSpin.IsActive = false;
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangePassButton_Click(sender, e);
            }
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidatePasswordBox(OldPassBox.Password.Length > 0, OldPassBox) ? false : result;
            result = !ValidationHelper.ValidatePasswordBox(NewPasswordBox.Password.Length > 0, NewPasswordBox) ? false : result;
            result = !ValidationHelper.ValidatePasswordBox(ConfNewPasswordBox.Password.Equals(NewPasswordBox.Password), ConfNewPasswordBox) ? false : result;
            return result;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UserCredentials.Clear();
            LogIn newLoginWindow = new LogIn();
            newLoginWindow.Show();
        }
    }
}
