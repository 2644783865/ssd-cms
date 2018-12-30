using CMS.BE.DTO;
using CMS.BE.Models.Article;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for SubmitArticle.xaml
    /// </summary>
    public partial class SubmitArticle : MetroWindow
    {
        private IArticleCore core;
        private ISessionCore sessionCore;
        private ArticleDTO currentArticle;
        public SubmitArticle(ArticleDTO article)
        {
            InitializeComponent();
            core = new ArticleCore();
            sessionCore = new SessionCore();
            LoadSpecialSessions();
            currentArticle = article;
            if (article != null) FillArticleBoxes();
        }

        private void FillArticleBoxes()
        {
            Topic.Text = currentArticle.Topic;
            SSCheck.IsChecked = currentArticle.SpecialSessionId.HasValue;
            if (currentArticle.SpecialSessionId.HasValue) SSList.SelectedValue = currentArticle.SpecialSessionId.Value;
        }

        private async void LoadSpecialSessions()
        {
            SSList.ClearValue(ItemsControl.ItemsSourceProperty);
            SSList.DisplayMemberPath = "SpecialSessionDesc";
            SSList.SelectedValuePath = "SpecialSessionId";
            SSList.ItemsSource = await sessionCore.GetSpecialSessionsAsync(UserCredentials.Conference.ConferenceId);
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (SSCheck.IsChecked.Value && SSList.SelectedIndex < 0)
            {
                MessageBox.Show("Select special session");
            }
            else
            {
                if (Topic.Text.Length > 0)
                {
                    int? specialSession = null;
                    if (SSCheck.IsChecked.Value) specialSession = ((SpecialSessionDTO)SSList.SelectedItem).SpecialSessionId;

                    if (currentArticle == null)
                    {
                        var article = new ArticleDTO()
                        {
                            Topic = Topic.Text,
                            ConferenceID = UserCredentials.Conference.ConferenceId,
                            Status = "submitted",
                            SpecialSessionId = specialSession
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
                    else
                    {
                        currentArticle.Topic = Topic.Text;
                        currentArticle.SpecialSessionId = specialSession;

                        if (await core.EditArticleAsync(currentArticle))
                        {
                            MessageBox.Show("Successfully edited article");
                            Close();
                        }
                        else MessageBox.Show("Error occured while editing article");
                    }
                }
                else MessageBox.Show("Provide topic!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SSCheck_Checked(object sender, RoutedEventArgs e)
        {
            SSList.Visibility = SSCheck.IsChecked.Value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
