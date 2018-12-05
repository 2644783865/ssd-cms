using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IWelcomePackGiftCore : IDisposable
    {
        Task<List<WelcomePackGiftDTO>> GetWelcomePackGiftInfoAsync();
        Task<WelcomePackGiftDTO> GetWelcomePackGiftByIdAsync(int welcomePackGiftId);
        Task<bool> AddWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift);
        Task<bool> EditWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift);
        Task<bool> DeleteWelcomePackGiftAsync(int welcomePackGiftId);
    }
}
