using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for ArticlePanel.xaml
    /// </summary>
    public partial class ArticlePanel : MetroWindow
    {
        private IArticleCore core;
        public ArticlePanel()
        {
            InitializeComponent();
            core = new ArticleCore();
            LoadData();
        }

        private async void LoadData()
        {
            SubmittedList.ClearValue(ItemsControl.ItemsSourceProperty);
            SubmittedList.DisplayMemberPath = "Topic";
            SubmittedList.SelectedValuePath = "ArticleId";
            SubmittedList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "submitted");
            AcceptedList.ClearValue(ItemsControl.ItemsSourceProperty);
            AcceptedList.DisplayMemberPath = "Topic";
            AcceptedList.SelectedValuePath = "ArticleId";
            AcceptedList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "accepted");
            RejectedList.ClearValue(ItemsControl.ItemsSourceProperty);
            RejectedList.DisplayMemberPath = "Topic";
            RejectedList.SelectedValuePath = "ArticleId";
            RejectedList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "rejected");
        }

        private void SubmittedList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                ArticleDetails newWindow = new ArticleDetails((ArticleDTO)((ListBox)sender).SelectedItem);
                newWindow.ShowDialog();
            }
        }

        private void MetroWindow_Activated(object sender, System.EventArgs e)
        {
            LoadData();
        }
    }
}
