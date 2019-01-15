using CMS.BE.Models.Authentication;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : MetroWindow
    {
        public LogIn()
        {
            InitializeComponent();
            UserCredentials.Clear();
            LoginFailed.Visibility = Visibility.Hidden;
            LoginBox.Focus();
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            LoginFailed.Visibility = Visibility.Hidden;
            LogInButton.IsEnabled = false;

            if (LoginBox.Text.Length > 0 && PasswordBox.Password.Length > 0)
            {
                using (IAuthenticationCore core = new AuthenticationCore())
                {
                    var loginModel = new LoginModel()
                    {
                        Login = LoginBox.Text,
                        Password = PasswordBox.Password
                    };

                    if (core.AdminLogin(loginModel))
                    {
                        AdministratorPanel newAdministratorWindow = new AdministratorPanel();
                        newAdministratorWindow.Show();
                        Close();
                    }
                    else
                    {
                        if (await core.LoginAsync(loginModel))
                        {
                            LoginFailed.Visibility = Visibility.Hidden;
                            UserPanel newMainWindow = new UserPanel();
                            newMainWindow.Show();
                            Close();
                        }
                        else
                        {
                            LoginFailed.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            else MessageBox.Show("Invalid form");
            ProgressSpin.IsActive = false;
            LogInButton.IsEnabled = true;
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LogInButton_Click(sender, e);
            }
        }

    }
}
