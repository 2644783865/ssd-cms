using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class WelcomePackRepository : IWelcomePackRepository
    {
        private cmsEntities _db = new cmsEntities();

        //WelcomePack
        public IEnumerable<WelcomePackDTO> GetWelcomePackInfo()
        {
            return _db.WelcomePacks.Project().To<WelcomePackDTO>();
        }

        public WelcomePackDTO GetWelcomePackById(int welcomePackId)
        {
            var welcomePack = _db.WelcomePacks.Find(welcomePackId);
            if (welcomePack == null) return null;
            else return MapperExtension.mapper.Map<WelcomePack, WelcomePackDTO>(welcomePack);
        }

        public void AddWelcomePack(WelcomePackDTO welcomePackDTO)
        {
            var welcomePack = MapperExtension.mapper.Map<WelcomePackDTO, WelcomePack>(welcomePackDTO);
            _db.WelcomePacks.Add(welcomePack);
            _db.SaveChanges();
        }

        public void EditWelcomePack(WelcomePackDTO welcomePackDTO)
        {
            var welcomePack = MapperExtension.mapper.Map<WelcomePackDTO, WelcomePack>(welcomePackDTO);
            _db.Entry(welcomePack).CurrentValues.SetValues(welcomePack);
            _db.SaveChanges();

        }

        public void DeleteWelcomePack(int welcomePackId)
        {
            var welcomePack = _db.WelcomePacks.Find(welcomePackId);
            _db.WelcomePacks.Remove(welcomePack);
            _db.SaveChanges();
        }

        //WelcomePackGift
        public IEnumerable<WelcomePackGiftDTO> GetWelcomePackGiftInfo()
        {
            return _db.WelcomePackGifts.Project().To<WelcomePackGiftDTO>();
        }

        public WelcomePackGiftDTO GetWelcomePackGiftById(int welcomePackGiftId)
        {
            var welcomePackGift = _db.WelcomePackGifts.Find(welcomePackGiftId);
            if (welcomePackGift == null) return null;
            else return MapperExtension.mapper.Map<WelcomePackGift, WelcomePackGiftDTO>(welcomePackGift);
        }

        public void AddWelcomePackGift(WelcomePackGiftDTO welcomePackGiftDTO)
        {
            var welcomePackGift = MapperExtension.mapper.Map<WelcomePackGiftDTO, WelcomePackGift>(welcomePackGiftDTO);
            _db.WelcomePackGifts.Add(welcomePackGift);
            _db.SaveChanges();
        }

        public void EditWelcomePackGift(WelcomePackGiftDTO welcomePackGiftDTO)
        {
            var welcomePackGift = MapperExtension.mapper.Map<WelcomePackGiftDTO, WelcomePackGift>(welcomePackGiftDTO);
            _db.Entry(welcomePackGift).CurrentValues.SetValues(welcomePackGift);
            _db.SaveChanges();

        }

        public void DeleteWelcomePackGift(int welcomePackGiftId)
        {
            var welcomePackGift = _db.WelcomePackGifts.Find(welcomePackGiftId);
            _db.WelcomePackGifts.Remove(welcomePackGift);
            _db.SaveChanges();
        }

        //WelcomePackReciever
        public IEnumerable<WelcomePackReceiverDTO> GetWelcomePackReceiverInfo()
        {
            return _db.WelcomePackReceivers.Project().To<WelcomePackReceiverDTO>();
        }

        public WelcomePackReceiverDTO GetWelcomePackReceiverById(int welcomePackReceiverId)
        {
            var welcomePackReceiver = _db.WelcomePackReceivers.Find(welcomePackReceiverId);
            if (welcomePackReceiver == null) return null;
            else return MapperExtension.mapper.Map<WelcomePackReceiver, WelcomePackReceiverDTO>(welcomePackReceiver);
        }

        public void AddWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO)
        {
            var welcomePackReceiver = MapperExtension.mapper.Map<WelcomePackReceiverDTO, WelcomePackReceiver>(welcomePackReceiverDTO);
            _db.WelcomePackReceivers.Add(welcomePackReceiver);
            _db.SaveChanges();
        }

        public void EditWelcomePackReceiver(WelcomePackReceiverDTO welcomePackReceiverDTO)
        {
            var welcomePackReceiver = MapperExtension.mapper.Map<WelcomePackReceiverDTO, WelcomePackReceiver>(welcomePackReceiverDTO);
            _db.Entry(welcomePackReceiver).CurrentValues.SetValues(welcomePackReceiver);
            _db.SaveChanges();

        }

        public void DeleteWelcomePackReceiver(int welcomePackReceiverId)
        {
            var welcomePackReceiver = _db.WelcomePackReceivers.Find(welcomePackReceiverId);
            _db.WelcomePackReceivers.Remove(welcomePackReceiver);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
