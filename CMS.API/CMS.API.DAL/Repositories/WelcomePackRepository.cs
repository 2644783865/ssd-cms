using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class WelcomePackRepository : IWelcomePackRepository
    {
        private cmsEntities _db = new cmsEntities();

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

        public IEnumerable<WelcomePackReceiverDTO> GetGuestsByConferenceId(int id)
        {
            var guests = _db.WelcomePackReceivers.Where(info => info.ConferenceId == id);
            foreach (var guest in guests)
            {
                yield return MapperExtension.mapper.Map<WelcomePackReceiver, WelcomePackReceiverDTO>(guest);
            }
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
            _db.Entry(_db.WelcomePackReceivers.Find(welcomePackReceiverDTO.WelcomePackReceiverId)).CurrentValues.SetValues(welcomePackReceiver);
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
