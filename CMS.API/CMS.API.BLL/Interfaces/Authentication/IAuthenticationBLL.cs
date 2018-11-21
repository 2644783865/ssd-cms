using CMS.API.DAL;
using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces.Authentication
{
    public interface IAuthenticationBLL
    {
        int Login(LoginModel loginModel);
        bool CheckCredentials(LoginModel loginModel);
        bool AddAccount(AccountDTO accountModel);
        bool ChangePassword(ChangePasswordModel changePasswordModel);
        IEnumerable<RoleDTO> GetRoles();
        string GetRoleName(int roleId);
        IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId);
        bool SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId);
        bool AddRole(string name);
        AccountDTO GetAccountByLogin(string login);
    }
}
