using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Account
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : MetroWindow
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm())
            {
                using (IAuthenticationCore core = new AuthenticationCore())
                {
                    var loginModel = new AccountDTO()
                    {
                        Login = LoginBox.Text,
                        Name = NameBox.Text,
                        PhoneNumber = PhoneBox.Text,
                        Email = EmailBox.Text
                    };


                    if (await core.AddAccountAsync(loginModel))
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Failure");
                    }
                }
            }
            else MessageBox.Show("Form invalid");
            ProgressSpin.IsActive = false;
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(LoginBox.Text.Length > 0, LoginBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(NameBox.Text.Length > 0, NameBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(PhoneBox.Text.Length > 0 && ConstraintHelper.ValidatePhoneNumber(PhoneBox.Text), PhoneBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(ConstraintHelper.ValidateEmail(EmailBox.Text), EmailBox) ? false : result;
            return result;
        }
    }
}
