using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
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
            SubmittedList.DisplayMemberPath = "Topic";
            SubmittedList.SelectedValuePath = "ArticleId";
            SubmittedList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "submitted");
            AcceptedList.DisplayMemberPath = "Topic";
            AcceptedList.SelectedValuePath = "ArticleId";
            AcceptedList.ItemsSource = (await core.GetArticlesAsync(UserCredentials.Conference.ConferenceId))
                .Where(article => article.Status == "accepted");
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
    }
}
