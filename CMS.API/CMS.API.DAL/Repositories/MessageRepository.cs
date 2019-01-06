using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CMS.API.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<MessageDTO> GetMessages()
        {
            return _db.Messages.Project().To<MessageDTO>();
        }

        public MessageDTO GetMessageById(int messageId)
        {

            var message = _db.Messages.Find(messageId);
            if (message == null) return null;
            else return MapperExtension.mapper.Map<Message, MessageDTO>(message);
        }

        public IEnumerable<MessageDTO> GetMessagesByAccountId(int accountId)
        {
            return _db.Messages.Where(message => message.SenderId == accountId || message.ReceiverId == accountId).Project().To<MessageDTO>();
        }

        public IEnumerable<MessageDTO> GetMessagesBySenderId(int senderId)
        {
            var msg = _db.Messages.Where(message => message.SenderId == senderId).Project().To<MessageDTO>();
            if (msg == null) return null;
            else return msg;
        }

        public IEnumerable<MessageDTO> GetMessagesByReceiverId(int receiverId)
        {
            var msg = _db.Messages.Where(message => message.ReceiverId == receiverId).Project().To<MessageDTO>();
            if (msg == null) return null;
            else return msg;
        }

        public void AddMessage(MessageDTO messageDTO)
        {
            var message = MapperExtension.mapper.Map<MessageDTO, Message>(messageDTO);
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        public void EditMessage(MessageDTO messageDTO)
        {
            var message = MapperExtension.mapper.Map<MessageDTO, Message>(messageDTO);
            _db.Entry(_db.Messages.Find(messageDTO.MessageId)).CurrentValues.SetValues(message);
            _db.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = _db.Messages.Find(messageId);
            _db.Messages.Remove(message);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<LastMessageDTO> GetLastMessagesByAccountId(int accountId)
        {
            return _db.LastMessages.Where(message => message.FirstId == accountId || message.SecondId == accountId).Project().To<LastMessageDTO>(); 
        }

        public IEnumerable<MessageDTO> GetMessagesByTargetId(int requesterId, int targetId)
        {
            return _db.Messages.Where(message => (message.ReceiverId == requesterId &&  message.SenderId == targetId) || (message.ReceiverId == targetId && message.SenderId == requesterId)).Project().To<MessageDTO>();

        }

        public void MarkReceived(int firstId, int secondId)
        {
            var sql = @"update LastMessages
	                    set FirstidReceived =1, secondidReceived=1
	                    where (FirstId=@arg_firstId and SecondId=@arg_secondId ) or (FirstId=@arg_secondId and SecondId=@arg_firstId)";
            _db.Database.ExecuteSqlCommand(sql, firstId, secondId);
        }
    }
}
