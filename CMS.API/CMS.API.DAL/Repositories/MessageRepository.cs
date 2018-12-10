using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Linq;
using System.Collections.Generic;

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
        public IEnumerable<MessageDTO> GetMessagesBySenderId(int senderId)
        {
            return _db.Messages.Where(message => message.SenderId == senderId).Select(message => message.Content).Distinct().Project().To<MessageDTO>();
         
        }

        public IEnumerable<MessageDTO> GetMessagesByReceiverId(int receiverId)
        {
            return _db.Messages.Where(message => message.ReceiverId == receiverId).Select(message => message.Content).Distinct().Project().To<MessageDTO>();
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
    }
}
