using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Windows.Articles;
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

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for PresentationDetails.xaml
    /// </summary>
    public partial class PresentationDetails : MetroWindow
    {
        private PresentationDTO presentation;
        private IAuthenticationCore authCore;
        private IArticleCore articleCore;
        private ISessionCore sessionCore;
        public PresentationDetails(PresentationDTO presentation)
        {
            InitializeComponent();
            this.presentation = presentation;
            authCore = new AuthenticationCore();
            articleCore = new ArticleCore();
            sessionCore = new SessionCore();
            FillPresentationBoxes();
        }

        private async void FillPresentationBoxes()
        {
            try
            {
                IdLabel.Content = presentation.PresentationId;
                TitleBox.Text = presentation.Title;
                DescriptionBox.Text = presentation.Title;
                PresenterBox.Text = (await authCore.GetAccountByIdAsync(presentation.PresenterId)).Login;
                ArticleLabel.Content = (await articleCore.GetArticleByIdAsync(presentation.ArticleId)).Topic;
                GradeLabel.Content = presentation.Grade.HasValue ? presentation.Grade.Value.ToString() : "-";
                SessionTypeLabel.Content = presentation.SpecialSessionId.HasValue ? "Special session:" : "Session:";
                SessionLabel.Content = presentation.SessionId.HasValue ?
                    (await sessionCore.GetSessionByIdAsync(presentation.SessionId.Value)).SessionDesc
                    : presentation.SpecialSessionId.HasValue
                    ? (await sessionCore.GetSpecialSessionByIdAsync(presentation.SpecialSessionId.Value)).SpecialSessionDesc
                    : "-";
            }
            catch
            {
                MessageBox.Show("Something went wrong while loading information");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var article = await articleCore.GetArticleByIdAsync(presentation.ArticleId);
            if (article != null)
            {
                ArticleDetails newWindow = new ArticleDetails(article);
                newWindow.ShowDialog();
            }
        }
    }
}
