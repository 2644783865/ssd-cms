using CMS.API.BLL.Models.Authentication;
using CMS.API.DAL;

namespace CMS.API.BLL.Interfaces.Authentication
{
    public interface IAuthenticationBLL
    {
        int Login(LoginModel loginModel);
        bool CheckCredentials(LoginModel loginModel);
        bool AddAccount(Account accountModel);
        bool ChangePassword(ChangePasswordModel changePasswordModel);
        object GetRoles();
        string GetRoleName(int roleId);
        object GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        object GetConferencesForAccount(int accountId);
        bool SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId);
        bool AddRole(string name);
        object GetAccountByLogin(string login);
    }
}
