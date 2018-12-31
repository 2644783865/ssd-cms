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
            List<MessageDTO> res = new List<MessageDTO>();
            try
            {
                var sendMsg = _repository.GetMessagesBySenderId(accountId);
                var recMsg = _repository.GetMessagesByReceiverId(accountId);
                foreach (MessageDTO msg in sendMsg)
                {
                    res.Add(msg);
                }
                foreach (MessageDTO msg in recMsg)
                {
                    res.Add(msg);
                }
            }
            catch
            {
                return null;
            }
            return res;
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
    }
}
