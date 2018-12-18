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
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Helpers;
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
        private ReviewDTO currentReview;

        public AddReview(ReviewDTO review)
        {
            InitializeComponent();
            core = new ReviewCore();
            currentReview = review;
            if (review != null) InitializeEditFields();
        }

        private void InitializeEditFields()
        {
            InitializeComponent();
        }


        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int grade = Convert.ToInt32(GradeBox.Text);
            if (ValidateForm())
            {
                bool result = false;
                if (currentReview == null)
                {
                    var review = new ReviewDTO()
                    {
                        Title = TitleBox.Text,
                        Grade = grade,
                        Comment = CommentBox.Text,
                        ReviewDate = DateTime.Now,
                        //missing review, reviewer and article ID
                    };
                    result = await core.AddReviewAsync(review);
                }
                else
                {
                    currentReview.Title = TitleBox.Text;
                    currentReview.Grade = grade;
                    currentReview.Comment = CommentBox.Text;
                    currentReview.ReviewDate = DateTime.Now;
                    //missing review, reviewer and article ID

                    result = await core.AddReviewAsync(currentReview);
                }
                if (result)
                {
                    MessageBox.Show("Success");
                    Close();
                }
                else MessageBox.Show("Failure");
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
            result = !ValidationHelper.ValidateTextFiled(GradeBox.Text.Length > 0, GradeBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(CommentBox.Text.Length > 0, CommentBox) ? false : result;
            return result;
        }

    }
}
