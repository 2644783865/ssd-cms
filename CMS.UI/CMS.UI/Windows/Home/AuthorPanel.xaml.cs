using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Home
{
    /// <summary>
    /// Interaction logic for AuthorPanel.xaml
    /// </summary>
    public partial class AuthorPanel : MetroWindow
    {
        private IArticleCore articleCore;
        public AuthorPanel()
        {
            InitializeComponent();
            WindowHelper.WindowSettings(this, UserLabel, ConferenceLabel);
            articleCore = new ArticleCore();
            InitializeData();
        }

        private async void InitializeData()
        {
            FillAuthorBoxes();
            await LoadArticles();
        }

        private void FillAuthorBoxes()
        {
            FirstNameLabel.Content = UserCredentials.Author.FirstName;
            LastNameLabel.Content = UserCredentials.Author.LastName;
            TitleLabel.Content = UserCredentials.Author.Title;
            FieldLabel.Content = UserCredentials.Author.FieldOfStudy;
        }

        private async Task LoadArticles()
        {
            if (UserCredentials.Account != null)
            {
                var articles = await articleCore.GetArticlesForConferenceAndAuthorAsync(UserCredentials.Conference.ConferenceId,
                    UserCredentials.Author.AuthorId);
                ArticleDataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                ArticleDataGrid.ItemsSource = articles;
            }
            else GoToUserPanelButton_Click(null, null);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.Logout(this);
        }

        private void GoToUserPanelButton_Click(object sender, RoutedEventArgs e)
        {
            UserPanel newWindow = new UserPanel();
            newWindow.Show();
            Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditArticles_Click(sender, e);
        }

        private void AddArticles_Click(object sender, RoutedEventArgs e)
        {
            SubmitArticle newSubmitArticleWindow = new SubmitArticle();
            newSubmitArticleWindow.ShowDialog();
        }

        private async void EditArticles_Click(object sender, RoutedEventArgs e)
        {
            if (ArticleDataGrid.SelectedIndex >= 0)
            {
                var article = await articleCore.GetArticleByIdAsync(((ArticleDTO)ArticleDataGrid.SelectedItem).ArticleId);
                ArticleDetails newArticleDetailsWindow = new ArticleDetails(article);
                newArticleDetailsWindow.ShowDialog();
            }
            else MessageBox.Show("Choose article first");
        }

        private async void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            if (ArticleDataGrid.SelectedIndex >= 0)
            {
                var result = await articleCore.DeleteArticleAsync(((ArticleDTO)ArticleDataGrid.SelectedItem).ArticleId);
                if (result)
                {
                    MessageBox.Show("Successfully deleted article");
                    await LoadArticles();
                }
                else MessageBox.Show("Error occured while deleting article");
            }
            else MessageBox.Show("Choose article first");
        }

        private async void MetroWindow_Activated(object sender, EventArgs e)
        {
            await LoadArticles();
        }
    }
}
