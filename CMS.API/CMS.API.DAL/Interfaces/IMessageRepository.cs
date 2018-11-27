using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<MessageDTO> GetMessages();
        MessageDTO GetMessageById(int groupId, int sequenceNumber);
        void AddMessage(MessageDTO messageDTO);
        void EditMessage(MessageDTO messageDTO);
        void DeleteMessage(int groupId, int sequenceNumber);
    }
}
