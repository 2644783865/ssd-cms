using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAuthenticationRepository : IDisposable
    {
        AccountDTO GetAccountByLogin(string login);
        AccountDTO GetAccountById(int id);
        void AddAccount(AccountDTO user);
        void ChangePassword(int accountId, string newPasswordHash);
        IEnumerable<RoleDTO> GetRoles();
        string GetRoleNameById(int roleId);
        IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId);
        IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId);
        void AddConferenceStaff(ConferenceStaff staff);
        void AddRole(RoleDTO role);
    }
}
