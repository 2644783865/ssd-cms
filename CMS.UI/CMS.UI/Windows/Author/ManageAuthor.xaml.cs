using CMS.Core.Core;
using CMS.Core.Interfaces;
using CMS.UI.Windows.Account;
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
            authCore = new AuthenticationCore();
            authorCore = new AuthorCore();
        }

        private async void GoToAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                    AddEditAuthor newAddAuthorWindow = new AddEditAuthor(null, account);
                    newAddAuthorWindow.ShowDialog();
                }
                else MessageBox.Show("Account doesn't exist");
            }
            else MessageBox.Show("Login empty");
        }

        private async void GoToEditAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                    var author = await authorCore.GetAuthorByAccountIdAsync(account.AccountId);
                    AddEditAuthor newAddAuthorWindow = new AddEditAuthor(author, account);
                    newAddAuthorWindow.ShowDialog();
                }
                else MessageBox.Show("Account doesn't exist");
            }
            else MessageBox.Show("Login empty");

        }

        private async void GoToDeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Length > 0)
            {
                if (await CheckAccountExistsAsync())
                {
                    var account = await authCore.GetAccountByLoginAsync(LoginBox.Text);
                    var author = await authorCore.GetAuthorByAccountIdAsync(account.AccountId);

                    if (await authorCore.DeleteAuthorAsync(author.AuthorId))
                        MessageBox.Show("Success");
                    else
                        MessageBox.Show("Failure");
                }
                else MessageBox.Show("Account doesn't exist");
            }
            else MessageBox.Show("Login empty");
        }

        private async Task<bool> CheckAccountExistsAsync()
        {
            return await authCore.GetAccountIdByLoginAsync(LoginBox.Text) >= 0;
        }
    }
}
