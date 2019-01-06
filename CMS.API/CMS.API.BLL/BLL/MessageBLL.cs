using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class MessageBLL : IMessageBLL
    {
        private IMessageRepository _repository = new MessageRepository();

        public IEnumerable<MessageDTO> GetMessages()
        {
            try
            {
                return _repository.GetMessages();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<MessageDTO> GetMessagesBySenderId(int senderId)
        {
            try
            {
                return _repository.GetMessagesBySenderId(senderId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<MessageDTO> GetMessagesByReceiverId(int receiverId)
        {
            try
            {
                return _repository.GetMessagesByReceiverId(receiverId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<MessageDTO> GetMessagesByAccountId(int accountId)
        {
            try
            {
                return _repository.GetMessagesByAccountId(accountId);
            }
            catch
            {
                return null;
            }
        }

        public MessageDTO GetMessageById(int messageId)
        {
            try
            {
                return _repository.GetMessageById(messageId);
            }
            catch
            {
                return null;
            }
        }

        public bool AddMessage(MessageDTO message)
        {
            try
            {
                _repository.AddMessage(message);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteMessage(int messageId)
        {
            try
            {
                _repository.DeleteMessage(messageId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditMessage(MessageDTO message)
        {
            try
            {
                _repository.EditMessage(message);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<LastMessageDTO> GetLastMessagesByAccountId(int accountId)
        {
            try
            {
                return _repository.GetLastMessagesByAccountId(accountId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<MessageDTO> GetMessagesByTargetId(int requesterId, int targetId)
        {
            try
            {
                return _repository.GetMessagesByTargetId(requesterId, targetId);
            }
            catch
            {
                return null;
            }
        }

        public bool markReceived(int FirstId, int SecondId)
        {
            try
            {
                _repository.MarkReceived(FirstId, SecondId);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
