using CMS.API.BLL.Helpers;
using CMS.API.BLL.Interfaces.Authentication;
using CMS.API.BLL.Models.Authentication;
using CMS.API.DAL;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;

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

        public bool AddAccount(Account accountModel)
        {
            var newAccount = new Account()
            {
                Name = accountModel.Name,
                PhoneNumber = accountModel.PhoneNumber,
                Email = accountModel.Email,
                Login = accountModel.Login,
                PasswordHash = string.IsNullOrEmpty(accountModel.PasswordHash) ? HashHelper.ComputeHash(AppSettings.DefaultPassword) 
                : HashHelper.ComputeHash(accountModel.PasswordHash)
            };

            try
            {
                _repository.AddAccount(newAccount);
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

        public object GetRoles()
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

        public object GetRolesForConferenceAndAccount(int conferenceId, int accountId)
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

        public object GetConferencesForAccount(int accountId)
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
            var newRole = new Role()
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

        public object GetAccountByLogin(string login)
        {
            var account =_repository.GetAccountByLogin(login);
            if (account == null) return null;
            return new Account() //omit password
            {
                Login = account.Login,
                Name = account.Name,
                PhoneNumber = account.PhoneNumber,
                Email = account.Email
            };
        }
    }
}
