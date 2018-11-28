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

        public void EditAccount(AccountDTO accountDTO)
        {
            var account = MapperExtension.mapper.Map<AccountDTO, Account>(accountDTO);
            _db.Entry(_db.Accounts.Find(accountDTO.AccountId)).CurrentValues.SetValues(account);
            _db.SaveChanges();
        }

        public void DeleteAccount(int accountId)
        {
            var account = _db.Accounts.Find(accountId);
            _db.Accounts.Remove(account);
            _db.SaveChanges();
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
            var roles = _db.Roles.Project().To<RoleDTO>();
            return roles.ToList();
        }

        public IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int conferenceId)
        {
            var selectedAccounts = _db.Accounts.Where(account => 
            account.ConferenceStaffs.Where(cs => cs.Role.Name.Equals(roleName) && cs.ConferenceId==conferenceId).Count() != 0);
            var result = selectedAccounts.Project().To<AccountDTO>();
            return result.ToList();
        }

        public string GetRoleName(int roleId)
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

        public ConferenceStaff GetConferenceStaff(int conferenceId, string accountLogin, int roleId)
        {
            return _db.ConferenceStaffs.Where(staff => staff.ConferenceId==conferenceId && staff.Account.Login.Equals(accountLogin) && staff.RoleId==roleId).FirstOrDefault();
        }

        public void AddConferenceStaff(ConferenceStaff staff)
        {
            _db.ConferenceStaffs.Add(staff);
            _db.SaveChanges();
        }

        public void DeleteConferenceStaff(int accountId, int roleId, int conferenceId)
        {
            var conferenceStaff = _db.ConferenceStaffs.Find(accountId, roleId, conferenceId);
            _db.ConferenceStaffs.Remove(conferenceStaff);
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
