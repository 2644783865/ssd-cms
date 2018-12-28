using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using MahApps.Metro.Controls;

namespace CMS.UI.Windows.Reviews
{
    /// <summary>
    /// Interaction logic for ReviewDetails.xaml
    /// </summary>
    public partial class ReviewDetails : MetroWindow
    {
        private IAuthenticationCore core;
        private ReviewDTO currentReview;
        public ReviewDetails(ReviewDTO review)
        {
            InitializeComponent();
            core = new AuthenticationCore();
            currentReview = review;
            LoadData();
        }

        private async void LoadData()
        {
            ArticleIdLabel.Content = currentReview.ArticleId;
            ReviewerLabel.Content = (await core.GetAccountByIdAsync(currentReview.ReviewerId)).Name;
            DateLabel.Content = currentReview.ReviewDate;
            TitleLabel.Content = currentReview.Title;
            GradeLabel.Content = currentReview.Grade;
            CommentBox.Text = currentReview.Comment;
        }
    }
}
