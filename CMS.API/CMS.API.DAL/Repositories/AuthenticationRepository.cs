using CMS.API.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private cmsEntities _db = new cmsEntities();

        public Account GetAccountByLogin(string login)
        {
            var account = _db.Accounts.FirstOrDefault(user => user.Login.Equals(login));
            if (account == null) return null;
            else return new Account()
            {
                AccountId = account.AccountId,
                Email = account.Email,
                Login = account.Login,
                Name = account.Name,
                PasswordHash = account.PasswordHash,
                PhoneNumber = account.PhoneNumber
            };
        }

        public Account GetAccountById(int id)
        {
            var account = _db.Accounts.Find(id);
            if (account == null) return null;
            else return new Account()
            {
                AccountId = account.AccountId,
                Email = account.Email,
                Login = account.Login,
                Name = account.Name,
                PasswordHash = account.PasswordHash,
                PhoneNumber = account.PhoneNumber
            };
        }

        public void AddAccount(Account user)
        {
            _db.Accounts.Add(user);
            _db.SaveChanges();
        }

        public void ChangePassword(int accountId, string newPasswordHash)
        {
            _db.Accounts.Find(accountId).PasswordHash = newPasswordHash;
            _db.SaveChanges();
        }

        public IEnumerable<Role> GetRoles()
        {
            foreach(var role in _db.Roles.ToList())
            {
                yield return new Role()
                {
                    RoleId = role.RoleId,
                    Name = role.Name
                };
            }
        }

        public string GetRoleNameById(int roleId)
        {
            return _db.Roles.Find(roleId).Name;
        }

        public IEnumerable<Role> GetRolesForConferenceAndAccount(int conferenceId, int accountId)
        {
            var roles = _db.ConferenceStaffs.Where(staff => staff.AccountId == accountId && staff.ConferenceId==conferenceId)
                .Select(staff => staff.Role).Distinct();
            foreach (var role in roles)
            {
                yield return new Role()
                {
                    RoleId = role.RoleId,
                    Name = role.Name
                };
            }
        }

        public IEnumerable<Conference> GetConferencesForAccount(int accountId)
        {
            var conferences = _db.ConferenceStaffs.Where(staff => staff.AccountId == accountId).Select(staff => staff.Conference).Distinct();
            foreach (var conference in conferences)
            {
                yield return new Conference()
                {
                    ConferenceId = conference.ConferenceId,
                    BeginDate = conference.BeginDate,
                    Description = conference.Description,
                    EndDate = conference.EndDate,
                    Place = conference.Place,
                    Title = conference.Title
                };
            }
        }

        public void AddConferenceStaff(ConferenceStaff staff)
        {
            _db.ConferenceStaffs.Add(staff);
            _db.SaveChanges();
        }

        public void AddRole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
