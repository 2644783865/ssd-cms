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

        IEnumerable<MessageDTO> GetMessagesByTargetId(int requesterId, int targetId);
        IEnumerable<LastMessageDTO> GetLastMessagesByAccountId(int accountId);
        MessageDTO GetMessageById(int messageId);
        bool AddMessage(MessageDTO message);
        bool EditMessage(MessageDTO message);
        bool DeleteMessage(int messageId);
        bool markReceived(int FirstId, int SecondId);
    }
}
