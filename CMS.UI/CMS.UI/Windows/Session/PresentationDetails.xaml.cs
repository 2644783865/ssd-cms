using CMS.BE.DTO;
using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using CMS.UI.Windows.Articles;
using MahApps.Metro.Controls;
using System.Windows;

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
        private IPresentationCore core;
        public PresentationDetails(PresentationDTO presentation)
        {
            InitializeComponent();
            this.presentation = presentation;
            authCore = new AuthenticationCore();
            articleCore = new ArticleCore();
            sessionCore = new SessionCore();
            core = new PresentationCore();
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

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                var account = await authCore.GetAccountByLoginAsync(PresenterBox.Text);
                if (account != null)
                {
                    presentation.Title = TitleBox.Text;
                    presentation.Description = DescriptionBox.Text;
                    presentation.PresenterId = account.AccountId;

                    if (await core.EditPresentationAsync(presentation))
                    {
                        MessageBox.Show("Successfully edited presentation");
                        Close();
                    }
                    else MessageBox.Show("Something went wrong while editing presentation");
                }
                else MessageBox.Show("Account with given login doesn't exits");
            }
            else MessageBox.Show("Form invalid");
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

        private bool ValidateForm()
        {
            var result = true;
            result = !ValidationHelper.ValidateTextFiled(TitleBox.Text.Length > 0, TitleBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(DescriptionBox.Text.Length > 0, DescriptionBox) ? false : result;
            result = !ValidationHelper.ValidateTextFiled(PresenterBox.Text.Length > 0, PresenterBox) ? false : result;
            return result;
        }
    }
}
