﻿using CMS.BE.DTO;
using CMS.BE.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IAuthenticationCore : IDisposable
    {
        bool AdminLogin(LoginModel loginModel);
        Task<bool> LoginAsync(LoginModel loginModel);
        Task LoadConferencesAsync();
        Task LoadRolesAsync();
        Task<List<RoleDTO>> GetRolesForOtherAccountAsync(string login);
        Task<AccountDTO> GetAccountByLoginAsync(string login);
        Task<int> GetAccountIdByLoginAsync(string login);
        Task<bool> AddAccountAsync(AccountDTO account);
        Task<bool> EditAccountAsync(AccountDTO account);
        Task<bool> DeleteAccountAsync(int accountId);
        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<List<RoleDTO>> GetHRRolesAsync();
        Task<bool> SetRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId);
        Task<bool> DeleteRoleForConferenceAndAccountAsync(int conferenceId, string login, int roleId);
        Task<bool> ChangePasswordAsync(ChangePasswordModel passwordModel);
        Task<bool> CheckIsManager(int conferenceId);
        Task<AccountDTO> GetAccountByIdAsync(int accountId);
    }
}
