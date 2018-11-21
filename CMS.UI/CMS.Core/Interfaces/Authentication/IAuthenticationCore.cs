using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.Core.Interfaces.Authentication
{
    public interface IAuthenticationCore : IDisposable
    {
        bool AdminLogin(LoginModel loginModel);
        Task<bool> LoginAsync(LoginModel loginModel);
        void LoadConferencesAsync(ComboBox conferencesBox);
        void LoadRolesAsync();
        Task<bool> AddAccountAsync(AccountDTO accountModel);
        void LoadAllRolesAsync(ComboBox rolesBox);
        Task<bool> SetRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId);
        Task<bool> ChangePasswordAsync(ChangePasswordModel passwordModel);
        Task<int> GetAccountByLoginAsync(string login);
    }
}
