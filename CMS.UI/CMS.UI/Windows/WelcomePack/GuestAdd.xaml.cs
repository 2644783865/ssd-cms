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
using MahApps.Metro.Controls;
using CMS.UI.Helpers;
using CMS.BE.DTO;
using CMS.Core.Interfaces;
using CMS.Core.Core;

namespace CMS.UI.Windows.WelcomePack
{
    /// <summary>
    /// Interaction logic for GuestAdd.xaml
    /// </summary>
    public partial class GuestAdd : MetroWindow
    {
        public GuestAdd()
        {
            InitializeComponent();
            this.Title = "Add Guest";
            AddButton.Content = "Add";
        }

        private async void Button_Add(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (IWelcomePackCore core = new WelcomePackCore())
                {
                    bool result = false;

                    var guestModel = new WelcomePackReceiverDTO()
                    {
                        FirstName = FirstNameBox.Text,
                        LastName = LastNameBox.Text,
                        Type = TitleNameBox.Text,
                        ConferenceId = UserCredentials.Conference.ConferenceId      
                    };
                    result = await core.AddWelcomePackReceiverAsync(guestModel);

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
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(FirstNameBox.Text.Length > 0, FirstNameBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(LastNameBox.Text.Length > 0, LastNameBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(TitleNameBox.Text.Length > 0, TitleNameBox) ? false : result;
            return result;
        }
    }
}
