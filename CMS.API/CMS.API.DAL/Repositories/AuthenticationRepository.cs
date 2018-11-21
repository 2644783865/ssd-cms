using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private cmsEntities _db = new cmsEntities();

        public AccountDTO GetAccountByLogin(string login)
        {
            var account = _db.Accounts.FirstOrDefault(user => user.Login.Equals(login));
            if (account == null) return null;
            else return MapperExtension.mapper.Map<Account, AccountDTO>(account);
        }

        public AccountDTO GetAccountById(int id)
        {
            var account = _db.Accounts.Find(id);
            if (account == null) return null;
            else return MapperExtension.mapper.Map<Account, AccountDTO>(account);
        }

        public void AddAccount(AccountDTO accountDTO)
        {
            var account = MapperExtension.mapper.Map<AccountDTO, Account>(accountDTO);
            _db.Accounts.Add(account);
            _db.SaveChanges();
        }

        public void ChangePassword(int accountId, string newPasswordHash)
        {
            _db.Accounts.Find(accountId).PasswordHash = newPasswordHash;
            _db.SaveChanges();
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            var test = _db.Roles.Project().To<RoleDTO>();
            return test.ToList();
        }

        public string GetRoleNameById(int roleId)
        {
            return _db.Roles.Find(roleId).Name;
        }

        public IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId)
        {
            return _db.ConferenceStaffs.Where(staff => staff.AccountId == accountId && staff.ConferenceId==conferenceId)
                .Select(staff => staff.Role).Distinct().Project().To<RoleDTO>();
        }

        public IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId)
        {
            return _db.ConferenceStaffs.Where(staff => staff.AccountId == accountId).Select(staff => staff.Conference).Distinct().Project().To<ConferenceDTO>();
        }

        public void AddConferenceStaff(ConferenceStaff staff)
        {
            _db.ConferenceStaffs.Add(staff);
            _db.SaveChanges();
        }

        public void AddRole(RoleDTO roleDTO)
        {
            var role = MapperExtension.mapper.Map<RoleDTO, Role>(roleDTO);
            _db.Roles.Add(role);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
