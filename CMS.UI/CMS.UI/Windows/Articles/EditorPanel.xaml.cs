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

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for EditorPanel.xaml
    /// </summary>
    public partial class EditorPanel : MetroWindow
    {
        public EditorPanel()
        {
            InitializeComponent();
        }

        private void Button_PDF(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ViewReviews(object sender, RoutedEventArgs e)
        {
      
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Accept(object sender, RoutedEventArgs e)
        {

        }
    }
}
