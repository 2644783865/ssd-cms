using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IAuthenticationBLL
    {
        AccountDTO Login(LoginModel loginModel);
        bool CheckCredentials(LoginModel loginModel);
        bool ChangePassword(ChangePasswordModel changePasswordModel);

        AccountDTO GetAccountById(int id);
        AccountDTO GetAccountByLogin(string login);
        bool AddAccount(AccountDTO accountModel);
        bool EditAccount(AccountDTO accountDTO);
        bool DeleteAccount(int accountId);

        IEnumerable<RoleDTO> GetRoles();
        IEnumerable<RoleDTO> GetHRRoles();
        string GetRoleName(int roleId);
        IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        bool AddRole(string name);
        bool SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId);
        bool DeleteAssignmentRoleForConferenceAndAccount(int conferenceId, string login, int roleId);
        IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int conferenceId);

        IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId);
    }
}
