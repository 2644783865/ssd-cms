using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using System.Windows.Controls;

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
            double average = 0;
            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    average += review.Grade;
                }
                average = average / reviews.Count;
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
