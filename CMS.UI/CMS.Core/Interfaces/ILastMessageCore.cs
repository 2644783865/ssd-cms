using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface ILastMessageCore : IDisposable
    {
        Task<LastMessageDTO> GetLastMessageByPairIdAsync(int pairId);
        Task<LastMessageDTO> GetLastMessageByFirstIdAsync(int firstId);
        Task<LastMessageDTO> GetLastMessageBySecondIdAsync(int secondId);
        Task<bool> AddLastMessageAsync(LastMessageDTO lastmessage);
        Task<bool> EditLastMessageAsync(LastMessageDTO lastmessage);
        Task<bool> DeleteLastMessageAsync(int pairId);
    }
}
