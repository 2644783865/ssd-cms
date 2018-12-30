using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<TravelInfoDTO> GetTravelInfo()
        {
            return _db.TravelInfoes.Project().To<TravelInfoDTO>();
        }

        public TravelInfoDTO GetTravelInfoById(int travelId)
        {
            var travel = _db.TravelInfoes.Find(travelId);
            if (travel == null) return null;
            else return MapperExtension.mapper.Map<TravelInfo, TravelInfoDTO>(travel);
        }

        public IEnumerable<TravelInfoDTO> GetTravelInfoByConferenceId(int id)
        {
            var infos = _db.TravelInfoes.Where(info => info.ConferenceId == id);
            foreach (var info in infos)
            {
                yield return MapperExtension.mapper.Map<TravelInfo, TravelInfoDTO>(info);
            }
        }

        public void AddTravel(TravelInfoDTO travelDTO)
        {
            var travel = MapperExtension.mapper.Map<TravelInfoDTO, TravelInfo>(travelDTO);
            _db.TravelInfoes.Add(travel);
            _db.SaveChanges();
        }

        public void EditTravel(TravelInfoDTO travelDTO)
        {
            var travel = MapperExtension.mapper.Map<TravelInfoDTO, TravelInfo>(travelDTO);
            _db.Entry(_db.TravelInfoes.Find(travelDTO.TravelInfoId)).CurrentValues.SetValues(travel);
            _db.SaveChanges();

        }

        public void DeleteTravel(int travelId)
        {
            var travel = _db.TravelInfoes.Find(travelId);
            _db.TravelInfoes.Remove(travel);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
