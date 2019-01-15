using MahApps.Metro.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;

namespace CMS.UI.Windows.Reviews
{
    /// <summary>
    /// Interaction logic for Reviwes.xaml
    /// </summary>
    public partial class ReviewsShow : MetroWindow
    {
        private IReviewCore core;
        public ReviewsShow()
        {
            InitializeComponent();
            core = new ReviewCore();
            LoadData();
        }

        private async void LoadData()
        {
            var reviews = await core.GetReviewInfoAsync(UserCredentials.Conference.ConferenceId);
            ReviewsGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            if (reviews != null) ReviewsGrid.ItemsSource = reviews.Where(r => r.ReviewerId == UserCredentials.Account.AccountId); ;
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsGrid.SelectedIndex >= 0)
            {
                ReviewDetails newWindow = new ReviewDetails((ReviewDTO)ReviewsGrid.SelectedItem);
                newWindow.ShowDialog();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReviewsGrid.SelectedIndex >= 0)
            {
                if (await core.DeleteReviewAsync(((ReviewDTO)ReviewsGrid.SelectedItem).ReviewId))
                {
                    MessageBox.Show("Successfully deleted review");
                    LoadData();
                }
                else MessageBox.Show("Something went wrong while deleting review");
            }
        }

        private void ReviewsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ReadButton_Click(null, null);
        }
    }
}
