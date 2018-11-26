using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageDTO> GetMessages();
        MessageDTO GetMessageById(int id);
        void AddMessage(MessageDTO messageDTO);
        void EditMessage(MessageDTO messageDTO);
        void DeleteMessage(int messageId);
    }
}
