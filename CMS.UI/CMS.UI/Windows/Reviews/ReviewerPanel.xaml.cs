using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Reviews
{
    /// <summary>
    /// Interaction logic for ReviewerPanel.xaml
    /// </summary>
    public partial class ReviewerPanel : MetroWindow
    {
        private IArticleCore core;
        public ReviewerPanel()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            core = new ArticleCore();
            LoadData();
        }

        private async void LoadData()
        {
            ArticlesList.ClearValue(ItemsControl.ItemsSourceProperty);
            ArticlesList.DisplayMemberPath = "Topic";
            ArticlesList.SelectedValuePath = "ArticleId";
            ArticlesList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "submitted");
        }

        private void MyReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            ReviewsShow newWindow = new ReviewsShow();
            newWindow.ShowDialog();
        }

        private void ArticlesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ArticlesList.SelectedItem != null)
            {
                ArticleDetails newWindow = new ArticleDetails((ArticleDTO)ArticlesList.SelectedItem);
                newWindow.ShowDialog();
            }
        }
    }
}
