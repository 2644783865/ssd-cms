using CMS.BE.DTO;
using System.Collections.Generic;


namespace CMS.API.BLL.Interfaces
{
    public interface IMessageBLL
    {
        IEnumerable<MessageDTO> GetMessages();
        IEnumerable<MessageDTO> GetMessagesBySenderId(int senderId);
        IEnumerable<MessageDTO> GetMessagesByReceiverId(int receiverId);
        IEnumerable<MessageDTO> GetMessagesByAccountId(int accountId);
        MessageDTO GetMessageById(int messageId);
        bool AddMessage(MessageDTO message);
        bool EditMessage(MessageDTO message);
        bool DeleteMessage(int messageId);
    }
}
