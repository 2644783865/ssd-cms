using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Windows;

namespace CMS.UI.Windows.Articles
{
    /// <summary>
    /// Interaction logic for AssignAuthor.xaml
    /// </summary>
    public partial class AssignAuthor : MetroWindow
    {
        private IAuthorCore authorCore;
        private IAuthenticationCore authCore;
        private IArticleCore articleCore;
        private int articleId;
        public AssignAuthor(int articleId)
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            authorCore = new AuthorCore();
            authCore = new AuthenticationCore();
            articleCore = new ArticleCore();
            this.articleId = articleId;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                if (account == null)
                {
                    MessageBox.Show("Account with a given login doesn't exist");
                    return;
                }
                var author = await authorCore.GetAuthorByAccountIdAsync(account.AccountId);
                if (author == null)
                {
                    MessageBox.Show("A given account is not an author");
                    return;
                }
                if (await articleCore.SetAuthorForArticleAsync(articleId, author.AuthorId))
                {
                    MessageBox.Show("Successfully added new author to article");
                    Close();
                }
                else MessageBox.Show("Something went wrong while adding new author to article");
            }
            else MessageBox.Show("Login cannot be empty");
        }
    }
}
