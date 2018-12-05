using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IWelcomePackReceiverCore : IDisposable
    {
        Task<List<WelcomePackReceiverDTO>> GetWelcomePackReceiverInfoAsync();
        Task<WelcomePackReceiverDTO> GetWelcomePackReceiverByIdAsync(int welcomePackReceiverId);
        Task<bool> AddWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver);
        Task<bool> EditWelcomePackReceiverAsync(WelcomePackReceiverDTO welcomePackReceiver);
        Task<bool> DeleteWelcomePackReceiverAsync(int welcomePackReceiverId);
    }
}
