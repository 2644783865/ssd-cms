using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAuthenticationRepository : IDisposable
    {
        void ChangePassword(int accountId, string newPasswordHash);

        AccountDTO GetAccountById(int id);
        AccountDTO GetAccountByLogin(string login);
        void AddAccount(AccountDTO accountDTO);
        void EditAccount(AccountDTO accountDTO);
        void DeleteAccount(int accountId);

        IEnumerable<RoleDTO> GetRoles();
        string GetRoleName(int roleId);
        IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        void AddRole(RoleDTO roleDTO);
        IEnumerable<ConferenceStaff> GetConferenceStaff(int conferenceId, string accountLogin, int roleId);
        void AddConferenceStaff(ConferenceStaff staff);
        void DeleteConferenceStaff(int conferenceStaffId);
        IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int conferenceId);

        IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId);
    }
}
