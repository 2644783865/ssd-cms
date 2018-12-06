using MahApps.Metro.Controls;
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


namespace CMS.UI.Windows.Author
{

    /// <summary>
    /// Interaction logic for AddEditAuthor.xaml
    /// </summary>
    public partial class AddEditAuthor : MetroWindow
    {
        private AuthorDTO currentAuthor;
        private AccountDTO currentAccount;

        public AddEditAuthor(AuthorDTO author, AccountDTO account)
        {
            InitializeComponent();
            currentAuthor = author;
            currentAccount = account;
            if (author != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            FirstNameBox.Text = currentAuthor.FirstName;
            LastNameBox.Text = currentAuthor.LastName;
            TitleBox.Text = currentAuthor.Title;
            FieldOfStudyBox.Text = currentAuthor.FieldOfStudy;
            SubmitButton.Content = "Save";
            this.Title = "Edit Author";
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //missing validate form
            using (IAuthorCore core = new AuthorCore())
            {
                bool result = false;

                if (currentAuthor == null)
                {
                    var authorModel = new AuthorDTO()
                    {
                        FirstName = FirstNameBox.Text,
                        LastName = LastNameBox.Text,
                        Title = TitleBox.Text,
                        FieldOfStudy = FieldOfStudyBox.Text,
                        AccountId = currentAccount.AccountId 
                    };
                    result = await core.AddAuthorAsync(authorModel);
                }
                else
                {
                    currentAuthor.FirstName = FirstNameBox.Text;
                    currentAuthor.LastName = LastNameBox.Text;
                    currentAuthor.Title = TitleBox.Text;
                    currentAuthor.FieldOfStudy= FieldOfStudyBox.Text;

                    result = await core.EditAuthorAsync(currentAuthor);
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
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
