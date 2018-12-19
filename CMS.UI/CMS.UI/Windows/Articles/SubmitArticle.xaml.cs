using CMS.BE.DTO;
using CMS.BE.Models.Article;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for SubmitArticle.xaml
    /// </summary>
    public partial class SubmitArticle : MetroWindow
    {
        private IArticleCore core;
        public SubmitArticle()
        {
            InitializeComponent();
            core = new ArticleCore();
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (Topic.Text.Length > 0)
            {
                var article = new ArticleDTO()
                {
                    Topic = Topic.Text,
                    ConferenceID = UserCredentials.Conference.ConferenceId,
                    Status = "submitted"
                };

                var articleModel = new AddArticleModel()
                {
                    Article = article,
                    AuthorId = UserCredentials.Account.AccountId
                };

                if (await core.AddArticleAsync(articleModel))
                {
                    MessageBox.Show("Successfully added article");
                    Close();
                }
                else MessageBox.Show("Error occured while adding article");
            }
            else MessageBox.Show("Provide topic!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
