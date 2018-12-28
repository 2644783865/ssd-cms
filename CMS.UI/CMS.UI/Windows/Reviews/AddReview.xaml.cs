using MahApps.Metro.Controls;
using System;
using System.Windows;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;

namespace CMS.UI.Windows.Reviews
{
    /// <summary>
    /// Interaction logic for AddReview.xaml
    /// </summary>
    public partial class AddReview : MetroWindow
    {
        private IReviewCore core;
        private ArticleDTO article;

        public AddReview(ArticleDTO article)
        {
            InitializeComponent();
            core = new ReviewCore();
            this.article = article;
            FillGradeBox();
        }

        private void FillGradeBox()
        {
            GradeBox.Items.Add(0.0);
            GradeBox.Items.Add(0.5);
            GradeBox.Items.Add(1.0);
            GradeBox.Items.Add(1.5);
            GradeBox.Items.Add(2.0);
            GradeBox.Items.Add(2.5);
            GradeBox.Items.Add(3.0);
            GradeBox.Items.Add(3.5);
            GradeBox.Items.Add(4.0);
            GradeBox.Items.Add(4.5);
            GradeBox.Items.Add(5.0);
        }


        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var review = new ReviewDTO()
                {
                    Title = TitleBox.Text,
                    Grade = float.Parse(GradeBox.SelectedValue.ToString()),
                    Comment = CommentBox.Text,
                    ReviewDate = DateTime.Now,
                    ReviewerId = UserCredentials.Account.AccountId,
                    ArticleId = article.ArticleId
                };
                if (await core.AddReviewAsync(review))
                {
                    MessageBox.Show("Successfully added review");
                    Close();
                }
                else MessageBox.Show("Something went wrong while adding a review");
            }
            else MessageBox.Show("Invalid form");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateComboBox(GradeBox.SelectedIndex >= 0, GradeBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(CommentBox.Text.Length > 0, CommentBox) ? false : result;
            return result;
        }

    }
}
