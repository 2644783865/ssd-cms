using CMS.API.BLL.Helpers;
using CMS.API.BLL.Interfaces;
using CMS.API.DAL;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class AuthenticationBLL : IAuthenticationBLL
    {
        private IAuthenticationRepository _repository = new AuthenticationRepository();

        public AccountDTO Login(LoginModel loginModel)
        {
            try
            {
                var foundAccount = _repository.GetAccountByLogin(loginModel.Login);
                if (foundAccount != null)
                {
                    if (HashHelper.ComputeHash(loginModel.Password).Equals(foundAccount.PasswordHash))
                    {
                        return foundAccount;
                    }
                }
            }
            catch { }
            return null;
        }

        public bool CheckCredentials(LoginModel loginModel)
        {
            try
            {
                var foundAccount = _repository.GetAccountByLogin(loginModel.Login);
                if (foundAccount != null)
                {
                    if (HashHelper.ComputeHash(loginModel.Password).Equals(foundAccount.PasswordHash)) return true;
                }
            }
            catch { }
            return false;
        }

        public bool ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                var foundAccount = _repository.GetAccountByLogin(changePasswordModel.Login);
                if (foundAccount != null)
                {
                    if (HashHelper.ComputeHash(changePasswordModel.Password).Equals(foundAccount.PasswordHash))
                    {
                        _repository.ChangePassword(foundAccount.AccountId, HashHelper.ComputeHash(changePasswordModel.NewPassword));
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }


        public AccountDTO GetAccountById(int id)
        {
            try
            {
                var account = _repository.GetAccountById(id);
                if (account == null) return null;
                account.PasswordHash = string.Empty; //omit password
                return account;
            }
            catch
            {
                return null;
            }
        }

        public AccountDTO GetAccountByLogin(string login)
        {
            try
            {
                var account = _repository.GetAccountByLogin(login);
                if (account == null) return null;
                account.PasswordHash = string.Empty; //omit password
                return account;
            }
            catch
            {
                return null;
            }
        }

        public bool AddAccount(AccountDTO account)
        {
            account.PasswordHash = string.IsNullOrEmpty(account.PasswordHash) ? HashHelper.ComputeHash(AppSettings.DefaultPassword)
                : HashHelper.ComputeHash(account.PasswordHash);
            try
            {
                _repository.AddAccount(account);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditAccount(AccountDTO account)
        {
            try
            {
                if (string.IsNullOrEmpty(account.PasswordHash))
                {
                    account.PasswordHash = _repository.GetAccountById(account.AccountId).PasswordHash;
                }
                else account.PasswordHash = HashHelper.ComputeHash(account.PasswordHash);
                _repository.EditAccount(account);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAccount(int accountId)
        {
            try
            {
                _repository.DeleteAccount(accountId);
            }
            catch
            {
                return false;
            }
            return true;
        }


        public IEnumerable<RoleDTO> GetRoles()
        {
            try
            {
                return _repository.GetRoles();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<RoleDTO> GetHRRoles()
        {
            try
            {
                return RoleHelper.FilterRolesForHRManagerToAssign(_repository.GetRoles() as List<RoleDTO>);
            }
            catch
            {
                return null;
            }
        }

        public string GetRoleName(int roleId)
        {
            try
            {
                return _repository.GetRoleName(roleId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<RoleDTO> GetRolesForConferenceAndAccount(int conferenceId, int accountId)
        {
            try
            {
                return _repository.GetRolesForConferenceAndAccount(conferenceId, accountId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddRole(string name)
        {
            var newRole = new RoleDTO()
            {
                Name = name
            };

            try
            {
                _repository.AddRole(newRole);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId)
        {
            var account = _repository.GetAccountByLogin(login);
            if (account == null) return false;
            var newConferenceStaff = new ConferenceStaff()
            {
                ConferenceId = conferenceId,
                AccountId = account.AccountId,
                RoleId = roleId
            };

            try
            {
                _repository.AddConferenceStaff(newConferenceStaff);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAssignmentRoleForConferenceAndAccount(int conferenceId, string login, int roleId)
        {
            if (!(_repository.GetConferenceStaff(conferenceId, login, roleId) is List<ConferenceStaff> staffs) || staffs.Count == 0) return false;

            foreach (var staff in staffs)
            {
                try
                {
                    _repository.DeleteConferenceStaff(staff.ConferenceStaffId);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int conferenceId)
        {
            try
            {
                return _repository.GetAccountsForRole(roleName, conferenceId);
            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<ConferenceDTO> GetConferencesForAccount(int accountId)
        {
            try
            {
                return _repository.GetConferencesForAccount(accountId);
            }
            catch
            {
                return null;
            }
        }
    }
}
