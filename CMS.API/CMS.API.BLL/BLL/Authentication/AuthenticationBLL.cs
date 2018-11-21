using CMS.API.BLL.Helpers;
using CMS.API.BLL.Interfaces.Authentication;
using CMS.API.DAL;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL.Authentication
{
    public class AuthenticationBLL : IAuthenticationBLL
    {
        private IAuthenticationRepository _repository = new AuthenticationRepository();

        public int Login(LoginModel loginModel)
        {
            var foundAccount = _repository.GetAccountByLogin(loginModel.Login);
            if (foundAccount != null)
            {
                if (HashHelper.ComputeHash(loginModel.Password).Equals(foundAccount.PasswordHash))
                {
                    return foundAccount.AccountId;
                }
            }
            return -1;
        }

        public bool CheckCredentials(LoginModel loginModel)
        {
            var foundAccount = _repository.GetAccountByLogin(loginModel.Login);
            if (foundAccount != null)
            {
                if (HashHelper.ComputeHash(loginModel.Password).Equals(foundAccount.PasswordHash)) return true;
            }
            return false;
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

        public bool ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var foundAccount = _repository.GetAccountByLogin(changePasswordModel.Login);
            if (foundAccount != null)
            {
                if (HashHelper.ComputeHash(changePasswordModel.Password).Equals(foundAccount.PasswordHash))
                {
                    try
                    {
                        _repository.ChangePassword(foundAccount.AccountId, HashHelper.ComputeHash(changePasswordModel.NewPassword));
                    }
                    catch
                    {
                        return false;
                    }
                    return true; ;
                }
            }
            return false;
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            return _repository.GetRoles();
        }

        public string GetRoleName(int roleId)
        {
            try
            {
                return _repository.GetRoleNameById(roleId);
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

        public bool SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId)
        {
            var account =_repository.GetAccountByLogin(login);
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

        public AccountDTO GetAccountByLogin(string login)
        {
            var account =_repository.GetAccountByLogin(login);
            if (account == null) return null;
            account.PasswordHash = string.Empty; //omit password
            return account;
        }
    }
}
