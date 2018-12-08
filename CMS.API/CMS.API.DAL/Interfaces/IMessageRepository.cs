using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageDTO> GetMessages();
        MessageDTO GetMessageBySenderId(int senderId);
        MessageDTO GetMessageByReceiverId(int receiverId);
        MessageDTO GetMessageById(int messageId);
        void AddMessage(MessageDTO messageDTO);
        void EditMessage(MessageDTO messageDTO);
        void DeleteMessage(int messageId);
    }
}
