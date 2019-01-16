using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using System.Windows.Controls;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.Reviews
{
    /// <summary>
    /// Interaction logic for Review.xaml
    /// </summary>
    public partial class Review : MetroWindow
    {
        private IReviewCore core;
        private ArticleDTO article;
        private List<ReviewDTO> reviews;
        public Review(ArticleDTO article)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            core = new ReviewCore();
            this.article = article;
            LoadData();
        }

        private async void LoadData()
        {
            reviews = await core.GetReviewsByArticleIdAsync(article.ArticleId);
            ReviewsBox.ClearValue(ItemsControl.ItemsSourceProperty);
            ReviewsBox.ItemsSource = reviews;
            CalculateAverage();
        }

        private void CalculateAverage()
        {
            decimal average = 0;
            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    average += review.Grade;
                }
                average = reviews.Count == 0 ? 0 : average / reviews.Count;
            }
            AvgGrade.Content = average;
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsBox.SelectedIndex >= 0)
            {
                ReviewDetails newWindow = new ReviewDetails((ReviewDTO)ReviewsBox.SelectedItem);
                newWindow.ShowDialog();
            }
            else MessageBox.Show("Select review first");
        }

        private void ReviewsBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailsButton_Click(null, null);
        }
    }
}
