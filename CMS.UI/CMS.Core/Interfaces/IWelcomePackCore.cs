using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IWelcomePackCore : IDisposable
    {
        Task<List<WelcomePackDTO>> GetWelcomePackInfoAsync();
        Task<WelcomePackDTO> GetWelcomePackByIdAsync(int welcomePackId);
        Task<bool> AddWelcomePackAsync(WelcomePackDTO welcomePack);
        Task<bool> EditWelcomePackAsync(WelcomePackDTO welcomePack);
        Task<bool> DeleteWelcomePackAsync(int welcomePackId);
    }
}
