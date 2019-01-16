using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Helpers;
using MahApps.Metro.Controls;
using System.Threading.Tasks;
using System.Windows;

namespace CMS.UI.Windows.Author
{
    /// <summary>
    /// Interaction logic for ManageAuthor.xaml
    /// </summary>
    public partial class ManageAuthor : MetroWindow
    {
        private IAuthenticationCore authCore;
        private IAuthorCore authorCore;

        public ManageAuthor()
        {
            InitializeComponent();
            WindowHelper.SmallWindowSettings(this);
            authCore = new AuthenticationCore();
            authorCore = new AuthorCore();
        }

        private async void GoToAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync(LoginBox.Text))
                {
                    if (!await CheckAuthorExistsAsync(LoginBox.Text))
                    {
                        var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                        AddEditAuthor newAddAuthorWindow = new AddEditAuthor(null, account);
                        newAddAuthorWindow.ShowDialog();
                    }
                    else MessageBox.Show("This account is already an author");
                }
                else MessageBox.Show("Account doesn't exist");
            }
            else MessageBox.Show("Login empty");
        }

        private async void GoToEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorBox.Text.Length > 0)
            {
                if (await CheckAuthorExistsAsync(AuthorBox.Text))
                {
                    var account = await authCore.GetAccountByLoginAsync(AuthorBox.Text);
                    var author = await authorCore.GetAuthorByAccountIdAsync(account.AccountId);
                    AddEditAuthor newAddAuthorWindow = new AddEditAuthor(author, account);
                    newAddAuthorWindow.ShowDialog();
                }
                else MessageBox.Show("Author doesn't exist");
            }
            else MessageBox.Show("Login empty");

        }

        private async void GoToDeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorBox2.Text.Length > 0)
            {
                if (await CheckAuthorExistsAsync(AuthorBox2.Text))
                {
                    var account = await authCore.GetAccountByLoginAsync(AuthorBox2.Text);
                    var author = await authorCore.GetAuthorByAccountIdAsync(account.AccountId);

                    if (await authorCore.DeleteAuthorAsync(author.AuthorId))
                        MessageBox.Show("Success");
                    else
                        MessageBox.Show("Failure");
                }
                else MessageBox.Show("Author doesn't exist");
            }
            else MessageBox.Show("Login empty");
        }

        private async Task<bool> CheckAccountExistsAsync(string login)
        {
            return await authCore.GetAccountIdByLoginAsync(login) >= 0;
        }

        private async Task<bool> CheckAuthorExistsAsync(string login)
        {
            var id = await authCore.GetAccountIdByLoginAsync(login);
            if (id >= 0)
            {
                return await authorCore.GetAuthorByAccountIdAsync(id) != null;
            }
            return false;
        }
    }
}
