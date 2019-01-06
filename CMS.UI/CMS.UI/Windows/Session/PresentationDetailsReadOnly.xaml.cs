using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Session
{
    /// <summary>
    /// Interaction logic for PresentationDetailsReadOnly.xaml
    /// </summary>
    public partial class PresentationDetailsReadOnly : MetroWindow
    {
        private IAuthenticationCore authCore;
        private IArticleCore articleCore;
        private ISessionCore sessionCore;
        private PresentationDTO presentation;

        public PresentationDetailsReadOnly(PresentationDTO presentation)
        {
            InitializeComponent();
            authCore = new AuthenticationCore();
            articleCore = new ArticleCore();
            sessionCore = new SessionCore();
            this.presentation = presentation;
            FillPresentationBoxes();
        }

        private async void FillPresentationBoxes()
        {
            try
            {
                IdLabel.Content = presentation.PresentationId;
                TitleLabel.Content = presentation.Title;
                DescriptionBox.Text = presentation.Description;
                PresenterLabel.Content = (await authCore.GetAccountByIdAsync(presentation.PresenterId)).Login;
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
