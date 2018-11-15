using CMS.BE;
using CMS.BE.Models;
using CMS.BE.Models.Authentication;
using CMS.Core.Helpers;
using CMS.Core.Interfaces.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CMS.Core.Core.Authentication
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
            if (result != null && result.ResponseType == ResponseType.Success 
                && int.TryParse(result.Content, out int id) && id > 0)
            {
                UserCredentials.AccountId = id;
                UserCredentials.Username = loginModel.Login;
                return true;
            }
            else return false;
        }

        public async void LoadConferencesAsync(ComboBox conferencesBox)
        {
            var path = $"{Properties.Resources.conferencesForAccountPath}?accountId={UserCredentials.AccountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                UserCredentials.Conferences = JsonConvert.DeserializeObject<List<BE.Conference>>(result.Content);
                foreach (var conference in UserCredentials.Conferences)
                {
                    conferencesBox.Items.Add($"{conference.ConferenceId} {conference.Title} {conference.BeginDate.ToShortDateString()}");
                }
            }
        }

        public async void LoadRolesAsync()
        {
            var path = $"{Properties.Resources.rolesForConferenceAndAccountPath}?conferenceId={UserCredentials.ConferenceId}&accountId={UserCredentials.AccountId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                UserCredentials.Roles = JsonConvert.DeserializeObject<List<Role>>(result.Content);
            }
        }

        public async void LoadAllRolesAsync(ComboBox rolesBox)
        {
            rolesBox.DisplayMemberPath = "Name";
            rolesBox.SelectedValuePath = "RoleId";

            var path = $"{Properties.Resources.rolesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                var roles = JsonConvert.DeserializeObject<List<Role>>(result.Content);
                foreach (var role in roles)
                {
                    rolesBox.Items.Add(role);
                }
            }
        }

        public async Task<bool> AddAccountAsync(Account accountModel)
        {
            var path = Properties.Resources.addAccountPath;
            var result = await _apiHelper.Post(path, accountModel);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> SetRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId)
        {
            var path = $"{Properties.Resources.setRoleForConferenceAndAccountPath}?conferenceId={conferenceId}&login={login}&roleId={roleId}";
            var result = await _apiHelper.Post(path, null);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordModel passwordModel)
        {
            var path = Properties.Resources.changePasswordPath;
            var result = await _apiHelper.Post(path, passwordModel);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<int> GetAccountByLoginAsync(string login)
        {
            var path = $"{Properties.Resources.accountByLoginPath}?login={login}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<Account>(result.Content).AccountId;
            }
            else return -1;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
