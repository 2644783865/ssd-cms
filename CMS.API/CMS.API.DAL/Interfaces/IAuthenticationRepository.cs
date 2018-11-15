using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAuthenticationRepository : IDisposable
    {
        Account GetAccountByLogin(string login);
        Account GetAccountById(int id);
        void AddAccount(Account user);
        void ChangePassword(int accountId, string newPasswordHash);
        IEnumerable<Role> GetRoles();
        string GetRoleNameById(int roleId);
        IEnumerable<Role> GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        IEnumerable<Conference> GetConferencesForAccount(int accountId);
        void AddConferenceStaff(ConferenceStaff staff);
        void AddRole(Role role);
    }
}
