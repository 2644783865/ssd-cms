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
using CMS.UI.Windows.Session;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for ArticleDetails.xaml
    /// </summary>
    public partial class ArticleDetails : MetroWindow
    {
        private ArticleDTO currentArticle;
        private IArticleCore core;
        private IPresentationCore presCore;
        private List<AuthorDTO> authors = new List<AuthorDTO>();
        public ArticleDetails(ArticleDTO article)
        {
            InitializeComponent();
            core = new ArticleCore();
            presCore = new PresentationCore();
            currentArticle = article;
            FillArticleBoxes();
        }

        private async void FillArticleBoxes()
        {
            IdLabel.Content = currentArticle.ArticleId;
            TopicBox.Text = currentArticle.Topic;
            StatusBox.Text = currentArticle.Status;
            AcceptanceDateBox.Text = currentArticle.AcceptanceDate.HasValue 
                ? currentArticle.AcceptanceDate.Value.ToShortDateString() : string.Empty;
            await LoadSubmissions();
            await LoadAuthors();
            SetVisibility();
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

        private void SetVisibility()
        {
            AddReview.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Reviewer)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            Accept.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            Reject.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null && currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            ChangeStatusButton.Visibility = UserCredentials.Roles.Find(r => r.Name.Equals(Properties.RoleResources.Editor)) != null && !currentArticle.Status.Equals("submitted") ? Visibility.Visible : Visibility.Collapsed;
            EditButton.Visibility = isAuthor() && currentArticle.Status.Equals("submitted") && SubmissionBox.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
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
            Submit.IsEnabled = false;
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
            Submit.IsEnabled = true;
        }

        private byte[] ReadData(Stream data)
        {
            var reader = new BinaryReader(data);
            return reader.ReadBytes((int)data.Length);
        }

        private async void PresentationButton_Click(object sender, RoutedEventArgs e)
        {
            Presentation.IsEnabled = false;
            if (currentArticle.PresentationId.HasValue)
            {
                var presentation = await presCore.GetPresentationByIdAsync(currentArticle.PresentationId.Value);
                PresentationDetails newWindow = new PresentationDetails(presentation);
                newWindow.ShowDialog();
            }
            Presentation.IsEnabled = true;
        }

        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Accept.IsEnabled = false;
            if (await core.AcceptArticleAsync(currentArticle.ArticleId, UserCredentials.Account.AccountId))
            {
                MessageBox.Show($"Article {currentArticle.Topic} accepted");
                Close();
            }
            else MessageBox.Show("Something went wrong while accepting article");
            Accept.IsEnabled = true;
        }

        private async void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            Reject.IsEnabled = false;
            if (await core.RejectArticleAsync(currentArticle.ArticleId, UserCredentials.Account.AccountId))
            {
                MessageBox.Show($"Article {currentArticle.Topic} rejected");
                Close();
            }
            else MessageBox.Show("Something went wrong while rejeting article");
            Reject.IsEnabled = true;
        }

        private async void View_Click(object sender, RoutedEventArgs e)
        {
            View.IsEnabled = false;
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
            View.IsEnabled = false;
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
            Reviews.IsEnabled = false;
            Review newReviewsWindow = new Review(currentArticle);
            newReviewsWindow.ShowDialog();
            Reviews.IsEnabled = true;
        }

        private void AddReview_Click(object sender, RoutedEventArgs e)
        {
            AddReview.IsEnabled = false;
            AddReview newAddReviewWindow = new AddReview(currentArticle);
            newAddReviewWindow.ShowDialog();
            AddReview.IsEnabled = true;
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButton.IsEnabled = false;
            SubmitArticle newWindow = new SubmitArticle(currentArticle);
            newWindow.ShowDialog();
            Close();
            EditButton.IsEnabled = true;
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            AddAuthorButton.IsEnabled = false;
            AssignAuthor newWindow = new AssignAuthor(currentArticle.ArticleId);
            newWindow.ShowDialog();
            AddAuthorButton.IsEnabled = true;
        }

        private async void DeleteAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteAuthorButton.IsEnabled = false;
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
            DeleteAuthorButton.IsEnabled = true;
        }

        private async void MetroWindow_Activated(object sender, EventArgs e)
        {
            await LoadAuthors();
            await LoadSubmissions();
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if(currentArticle.Status.Equals("rejected")) Accept.Visibility = Visibility.Visible;
            if (currentArticle.Status.Equals("accepted")) Reject.Visibility = Visibility.Visible;
        }
    }
}
