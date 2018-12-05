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

        Task<List<WelcomePackGiftDTO>> GetWelcomePackGiftInfoAsync();
        Task<WelcomePackGiftDTO> GetWelcomePackGiftByIdAsync(int welcomePackGiftId);
        Task<bool> AddWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift);
        Task<bool> EditWelcomePackGiftAsync(WelcomePackGiftDTO welcomePackGift);
        Task<bool> DeleteWelcomePackGiftAsync(int welcomePackGiftId);

        Task<List<WelcomePackReceiverDTO>> GetWelcomePackReceiverInfoAsync();
        Task<WelcomePackReceiverDTO> GetWelcomePackReceiverByIdAsync(int welcomePackReceiverId);
        Task<bool> AddWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver);
        Task<bool> EditWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver);
        Task<bool> DeleteWelcomePackReceiverAsync(int welcomePackReceiverId);
    }
}
