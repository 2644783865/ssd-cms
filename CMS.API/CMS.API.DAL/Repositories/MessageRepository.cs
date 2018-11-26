using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
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
        public MessageDTO GetMessageById(int id)
        {
            var message = _db.Messages.Find(id);
            if (message == null) return null;
            else return MapperExtension.mapper.Map<Message, MessageDTO>(message);
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
            _db.Entry(message).CurrentValues.SetValues(message);
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
