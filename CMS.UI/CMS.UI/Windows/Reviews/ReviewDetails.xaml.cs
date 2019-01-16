using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
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
            WindowHelper.SmallWindowSettings(this);
            core = new AuthenticationCore();
            currentReview = review;
            LoadData();
        }

        private async void LoadData()
        {
            ReviewerLabel.Content = (await core.GetAccountByIdAsync(currentReview.ReviewerId)).Name;
            TitleLabel.Content = currentReview.Title;
            GradeLabel.Content = currentReview.Grade;
            CommentBox.Text = currentReview.Comment;
        }
    }
}
