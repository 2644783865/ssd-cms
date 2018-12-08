using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class LastMessageRepository : ILastMessageRepository
    {
        private cmsEntities _db = new cmsEntities();

        public LastMessageDTO GetLastMessageByPairId(int PairId)
        {
            var lastMessage = _db.LastMessages.Find(PairId);
            if (lastMessage == null) return null;
            else return MapperExtension.mapper.Map<LastMessage, LastMessageDTO>(lastMessage);
        }
        public LastMessageDTO GetLastMessageByFirstId(int FirstId)
        {
            var lastMessage = _db.LastMessages.Find(FirstId);
            if (lastMessage == null) return null;
            else return MapperExtension.mapper.Map<LastMessage, LastMessageDTO>(lastMessage);
        }

        public LastMessageDTO GetLastMessageBySecondId(int SecondId)
        {
            var lastMessage = _db.LastMessages.Find(SecondId);
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
