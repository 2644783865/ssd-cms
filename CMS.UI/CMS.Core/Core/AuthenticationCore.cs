﻿using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.BE.Models.Authentication;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class AuthenticationCore : IAuthenticationCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public bool AdminLogin(LoginModel loginModel)
        {
            return loginModel.Login.Equals(AppSettings.AdminLogin) && loginModel.Password.Equals(AppSettings.AdminPassword);
        }

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var path = Properties.Resources.loginPath;
            var result = await _apiHelper.Post(path, loginModel);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                UserCredentials.Account = JsonConvert.DeserializeObject<AccountDTO>(result.Content);
                UserCredentials.Username = loginModel.Login;
                return true;
            }
            else return false;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordModel passwordModel)
        {
            var path = Properties.Resources.changePasswordPath;
            var result = await _apiHelper.Post(path, passwordModel);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<AccountDTO> GetAccountByLoginAsync(string login)
        {
            var path = $"{Properties.Resources.getAccountByLoginPath}?login={login}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<AccountDTO>(result.Content);
            }
            return null;
        }

        public async Task<int> GetAccountIdByLoginAsync(string login)
        {
            var account = await GetAccountByLoginAsync(login);
            if (account != null) return account.AccountId;
            else return -1;
        }

        public async Task<bool> AddAccountAsync(AccountDTO account)
        {
            var path = Properties.Resources.addAccountPath;
            var result = await _apiHelper.Post(path, account);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditAccountAsync(AccountDTO account)
        {
            var path = Properties.Resources.editAccountPath;
            var result = await _apiHelper.Put(path, account);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {
            var path = $"{Properties.Resources.deleteAccountPath}?accountId={accountId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }


        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var path = $"{Properties.Resources.getRolesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content);
            }
            return null;
        }

        public async Task<List<RoleDTO>> GetHRRolesAsync()
        {
            var path = $"{Properties.Resources.getHRRolesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content);
            }
            return null;
        }

        public async void LoadRolesAsync()
        {
            var path = $"{Properties.Resources.getRolesForConferenceAndAccountPath}?conferenceId={UserCredentials.Conference.ConferenceId}&accountId={UserCredentials.Account.AccountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                UserCredentials.Roles = JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content);
            }
        }

        public async Task<List<RoleDTO>> GetRolesForOtherAccountAsync(string login)
        {
            var account = await GetAccountByLoginAsync(login);
            var path = $"{Properties.Resources.getRolesForConferenceAndAccountPath}?conferenceId={UserCredentials.Conference.ConferenceId}&accountId={account.AccountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoleDTO>>(result.Content);
            }
            return null;
        }


        public async Task<bool> SetRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId)
        {
            var path = $"{Properties.Resources.setRoleForConferenceAndAccountPath}?conferenceId={conferenceId}&login={login}&roleId={roleId}";
            var result = await _apiHelper.Post(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId)
        {
            var path = $"{Properties.Resources.deleteRoleForConferenceAndAccountPath}?conferenceId={conferenceId}&login={login}&roleId={roleId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task LoadConferencesAsync()
        {
            var path = $"{Properties.Resources.getConferencesForAccountPath}?accountId={UserCredentials.Account.AccountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                UserCredentials.Conferences = JsonConvert.DeserializeObject<List<ConferenceDTO>>(result.Content);
            }
        }


        public void Dispose() => _apiHelper.Dispose();
    }
}