using MahApps.Metro.Controls;
using System.Windows;
using CMS.BE.DTO;
using CMS.Core.Core;
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
            WindowHelper.SmallWindowSettings(this);
            currentAuthor = author;
            currentAccount = account;
            FillTitleBox();
            if (author != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            FirstNameBox.Text = currentAuthor.FirstName;
            LastNameBox.Text = currentAuthor.LastName;
            TitleBox.SelectedValue = currentAuthor.Title;
            FieldOfStudyBox.Text = currentAuthor.FieldOfStudy;
            SubmitButton.Content = "Save";
            Title = "Edit Author";
        }

        private void FillTitleBox()
        {
            TitleBox.Items.Add("Bachelor");
            TitleBox.Items.Add("Master");
            TitleBox.Items.Add("Doctor");
            TitleBox.Items.Add("Professor");
            TitleBox.SelectedIndex = 0;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressSpin.IsActive = true;
            if (ValidateForm()) using (IAuthorCore core = new AuthorCore())
                {
                    bool result = false;

                    if (currentAuthor == null)
                    {
                        var authorModel = new AuthorDTO()
                        {
                            FirstName = FirstNameBox.Text,
                            LastName = LastNameBox.Text,
                            Title = TitleBox.SelectedValue.ToString(),
                            FieldOfStudy = FieldOfStudyBox.Text,
                            AccountId = currentAccount.AccountId
                        };
                        result = await core.AddAuthorAsync(authorModel);
                    }
                    else
                    {
                        currentAuthor.FirstName = FirstNameBox.Text;
                        currentAuthor.LastName = LastNameBox.Text;
                        currentAuthor.Title = TitleBox.SelectedValue.ToString();
                        currentAuthor.FieldOfStudy = FieldOfStudyBox.Text;

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
            else MessageBox.Show("Form invalid");
            ProgressSpin.IsActive = false;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(FirstNameBox.Text.Length > 0, FirstNameBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(LastNameBox.Text.Length > 0, LastNameBox) ? false : result;
            result = !ValidationHelper.ValidateComboBox(TitleBox.SelectedIndex >= 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(FieldOfStudyBox.Text.Length > 0, FieldOfStudyBox) ? false : result;
            return result;
        }

    }
}
