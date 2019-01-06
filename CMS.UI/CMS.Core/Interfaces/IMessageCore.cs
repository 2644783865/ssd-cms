using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IMessageCore : IDisposable
    {
        Task<List<MessageDTO>> GetMessagesAsync();
        Task<MessageDTO> GetMessageByIdAsync(int messageId);

        Task<List<MessageDTO>> GetMessagesByTargetIdAsync(int requesterId, int targetId);
        Task<MessageDTO> GetMessageBySenderIdAsync(int senderId);
        Task<MessageDTO> GetMessageByReceiverIdAsync(int receiverId);
        Task<List<MessageDTO>> GetMessagesByAccountIdAsync(int accountId);
        Task<List<LastMessageDTO>> GetLastMessagesByAccountIdAsync(int accountId);
        Task<bool> AddMessageAsync(MessageDTO message);
        Task<bool> EditMessageAsync(MessageDTO message);
        Task<bool> DeleteMessageAsync(int messageId);
        Task<int> HasNewMessages();
    }
}
