using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private cmsEntities _db = new cmsEntities();

        public void AddTravel(TravelInfoDTO travelDTO)
        {
            var travel = MapperExtension.mapper.Map<TravelInfoDTO, TravelInfo>(travelDTO);
            _db.TravelInfoes.Add(travel);
            _db.SaveChanges();
        }

        public void EditTravel(TravelInfoDTO travelDTO)
        {
            var travel = MapperExtension.mapper.Map<TravelInfoDTO, TravelInfo>(travelDTO);
            _db.Entry(travel).CurrentValues.SetValues(travel);
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
