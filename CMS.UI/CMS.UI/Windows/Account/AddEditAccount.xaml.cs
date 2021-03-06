﻿using CMS.BE.DTO;
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
    public partial class AddEditAccount : MetroWindow
    {
        private AccountDTO currentAccount;

        public AddEditAccount(AccountDTO account)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            currentAccount = account;
            if (account != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            LoginBox.Text = currentAccount.Login;
            LoginBox.IsReadOnly = true;
            NameBox.Text = currentAccount.Name;
            PhoneBox.Text = currentAccount.PhoneNumber;
            EmailBox.Text = currentAccount.Email;
            SubmitButton.Content = "Save";
            this.Title = "Edit Account";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm())
            {
                using (IAuthenticationCore core = new AuthenticationCore())
                {
                    bool result = false;

                    if (currentAccount == null)
                    {
                        var loginModel = new AccountDTO()
                        {
                            Login = LoginBox.Text,
                            Name = NameBox.Text,
                            PhoneNumber = PhoneBox.Text,
                            Email = EmailBox.Text
                        };
                        result = await core.AddAccountAsync(loginModel);
                        if (result)
                        {
                            MessageBox.Show("Successfully added account");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error occured while adding account");
                        }
                    }
                    else
                    {
                        currentAccount.Name = NameBox.Text;
                        currentAccount.PhoneNumber = PhoneBox.Text;
                        currentAccount.Email = EmailBox.Text;

                        result = await core.EditAccountAsync(currentAccount);
                        if (result)
                        {
                            MessageBox.Show("Successfully edited account");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error occured while editing account");
                        }
                    }
                }
            }
            else MessageBox.Show("Invalid form");
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
