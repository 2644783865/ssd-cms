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
    /// Interaction logic for Reviwes.xaml
    /// </summary>
    public partial class ReviewsShow : MetroWindow
    {
        public ReviewsShow()
        {
            InitializeComponent();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Review newReviewWindow = new Review();
            newReviewWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
