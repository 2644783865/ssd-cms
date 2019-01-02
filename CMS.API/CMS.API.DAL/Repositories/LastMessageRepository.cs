using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class LastMessageRepository : ILastMessageRepository
    {
        private cmsEntities _db = new cmsEntities();

        public LastMessageDTO GetLastMessageByPairId(int pairId)
        {
            var lastMessage = _db.LastMessages.Find(pairId);
            if (lastMessage == null) return null;
            else return MapperExtension.mapper.Map<LastMessage, LastMessageDTO>(lastMessage);
        }

        public IEnumerable<LastMessageDTO> GetLastMessagesByAccountId(int accountId)
        {
            return _db.LastMessages.Where(message => message.FirstId==accountId || message.SecondId==accountId).Project().To<LastMessageDTO>();
        }

        public LastMessageDTO GetLastMessageByFirstId(int firstId)
        {
            var lastMessage = _db.LastMessages.Where(message => message.FirstId == firstId).ToList().First();
            if (lastMessage == null) return null;
            else return MapperExtension.mapper.Map<LastMessage, LastMessageDTO>(lastMessage);
        }

        public LastMessageDTO GetLastMessageBySecondId(int secondId)
        {
            var lastMessage = _db.LastMessages.Where(message => message.SecondId == secondId).ToList().First();
            if (lastMessage == null) return null;
            else return MapperExtension.mapper.Map<LastMessage, LastMessageDTO>(lastMessage);
        }

        public void AddLastMessage(LastMessageDTO lastMessageDTO)
        {
            var lastMessage = MapperExtension.mapper.Map<LastMessageDTO, LastMessage>(lastMessageDTO);
            _db.LastMessages.Add(lastMessage);
            _db.SaveChanges();
        }

        public void EditLastMessage(LastMessageDTO lastMessageDTO)
        {
            var lastMessage = MapperExtension.mapper.Map<LastMessageDTO, LastMessage>(lastMessageDTO);
            _db.Entry(_db.LastMessages.Find(lastMessageDTO.PairId)).CurrentValues.SetValues(lastMessage);
            _db.SaveChanges();
        }

        public void DeleteLastMessage(int PairId)
        {
            var lastMessage = _db.LastMessages.Find(PairId);
            _db.LastMessages.Remove(lastMessage);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
