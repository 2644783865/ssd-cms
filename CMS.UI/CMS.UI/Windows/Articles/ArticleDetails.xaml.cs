using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using CMS.UI.Windows.Reviews;
using System.Windows.Controls;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for ArticleDetails.xaml
    /// </summary>
    public partial class ArticleDetails : MetroWindow
    {
        private ArticleDTO currentArticle;
        private IArticleCore core;
        private List<AuthorDTO> authors = new List<AuthorDTO>();
        public ArticleDetails(ArticleDTO article)
        {
            InitializeComponent();
            core = new ArticleCore();
            currentArticle = article;
            FillArticleBoxes();
        }

        private async void FillArticleBoxes()
        {
            IdLabel.Content = currentArticle.ArticleId;
            TopicBox.Text = currentArticle.Topic;
            StatusBox.Text = currentArticle.Status;
            AcceptanceDateBox.Text = currentArticle.AcceptanceDate.HasValue ? currentArticle.AcceptanceDate.Value.ToString() : string.Empty;
            await LoadSubmissions();
            await LoadAuthors();
            SetVisibility();
            SetReadOnly();
        }

        private async Task LoadSubmissions()
        {
            SubmissionBox.ClearValue(ItemsControl.ItemsSourceProperty);
            SubmissionBox.DisplayMemberPath = "SubmissionDate";
            SubmissionBox.SelectedValuePath = "SubmissionId";
            SubmissionBox.ItemsSource = await core.GetSubmissionsForArticleAsync(currentArticle.ArticleId);
            SubmissionBox.SelectedIndex = SubmissionBox.Items.Count > 0 ? 0 : -1;
        }

        private async Task LoadAuthors()
        {
            AuthorsBox.ClearValue(ItemsControl.ItemsSourceProperty);
            AuthorsBox.DisplayMemberPath = "AuthorDesc";
            AuthorsBox.SelectedValuePath = "AuthorId";
            authors = await core.GetAuthorsForArticleAsync(currentArticle.ArticleId);
            AuthorsBox.ItemsSource = authors;
            if (AuthorsBox.Items.Count == 4) AddAuthorButton.IsEnabled = false;
            else AddAuthorButton.IsEnabled = true;
            if (AuthorsBox.Items.Count == 1) DeleteAuthorButton.IsEnabled = false;
            else DeleteAuthorButton.IsEnabled = true;
        }

        private void SetReadOnly()
        {
            if (isAuthor() && currentArticle.Status.Equals("submitted"))
            {
                TopicBox.IsReadOnly = false;
            }
            else TopicBox.IsReadOnly = true;
        }

        private void SetVisibility()
        {
            AddReview.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Reviewer)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            Accept.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            Reject.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            EditButton.Visibility = isAuthor() && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            Submit.IsEnabled = isAuthor() && currentArticle.Status.Equals("submitted");
            Presentation.IsEnabled = currentArticle.Status.Equals("accepted");
            AddAuthorButton.Visibility = isAuthor() && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            DeleteAuthorButton.Visibility = isAuthor() && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
        }

        private bool isAuthor()
        {
            return authors.Find(auth => auth.AuthorId == UserCredentials.Author.AuthorId) != null;
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "pdf files (*.pdf)|*.pdf"
            };

            if ((bool)fileDialog.ShowDialog())
            {
                var articleFile = ReadData(File.OpenRead(fileDialog.FileName));
                var submission = new SubmissionDTO()
                {
                    SubmissionDate = DateTime.Now,
                    ArticleFile = articleFile,
                    ArticleId = currentArticle.ArticleId
                };
                var result = await core.AddSubmissionAsync(submission);
                if (result) MessageBox.Show("Successfully submitted article");
                else MessageBox.Show("Error occured while submitting article");
                await LoadSubmissions();
            }
        }

        private byte[] ReadData(Stream data)
        {
            var reader = new BinaryReader(data);
            return reader.ReadBytes((int)data.Length);
        }

        private void PresentationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (await core.AcceptArticleAsync(currentArticle.ArticleId, UserCredentials.Account.AccountId))
            {
                MessageBox.Show($"Article {currentArticle.Topic} accepted");
                Close();
            }
            else MessageBox.Show("Something went wrong while accepting article");
        }

        private async void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (await core.RejectArticleAsync(currentArticle.ArticleId, UserCredentials.Account.AccountId))
            {
                MessageBox.Show($"Article {currentArticle.Topic} rejected");
                Close();
            }
            else MessageBox.Show("Something went wrong while rejeting article");
        }

        private async void View_Click(object sender, RoutedEventArgs e)
        {
            if (SubmissionBox.SelectedIndex >= 0)
            {
                var selectedSubmission = (SubmissionDTO)SubmissionBox.SelectedItem;
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FileName = $"{currentArticle.Topic} submission {selectedSubmission.SubmissionDate.ToString("dd-MM-yyyy")}"
                };

                var submission = await core.GetSubmissionByIdAsync(selectedSubmission.SubmissionId);
                if ((bool)fileDialog.ShowDialog())
                {
                    WriteData(fileDialog.FileName, submission.ArticleFile);
                }
            }
            else MessageBox.Show("Select submission");
        }

        private void WriteData(string fileName, byte[] bytes)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.CreateNew)))
            {
                writer.Write(bytes);
            }
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            Review newReviewsWindow = new Review(currentArticle);
            newReviewsWindow.ShowDialog();
        }

        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            AddReview newAddReviewWindow = new AddReview(currentArticle);
            newAddReviewWindow.ShowDialog();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            if (AuthorsExpander.IsExpanded)
            {
                Height = 641;
                AuthorsExpander.Height = 118;
            }
            else
            {
                Height = 553;
                AuthorsExpander.Height = 30;
            }
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TopicBox.Text.Length > 0)
            {
                currentArticle.Topic = TopicBox.Text;
                if(await core.EditArticleAsync(currentArticle))
                {
                    MessageBox.Show("Successfully edited article");
                    Close();
                }
                else MessageBox.Show("Something went wrong while editing article");
            }
            else MessageBox.Show("Topic cannot be empty");
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            AssignAuthor newWindow = new AssignAuthor(currentArticle.ArticleId);
            newWindow.ShowDialog();
        }

        private async void DeleteAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsBox.SelectedIndex >= 0)
            {
                if (await core.DeleteAssignmentAuthorForArticleAsync(currentArticle.ArticleId,
                    ((AuthorDTO)AuthorsBox.SelectedItem).AuthorId))
                {
                    MessageBox.Show("Successfully removed author from article");
                    await LoadAuthors();
                }
                else MessageBox.Show("Something went wrong while removing author from article");
            }
            else MessageBox.Show("Select author first");
        }

        private async void MetroWindow_Activated(object sender, EventArgs e)
        {
            await LoadAuthors();
            await LoadSubmissions();
        }
    }
}
