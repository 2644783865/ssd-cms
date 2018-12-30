using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class AccommodationInfoRepository : IAccommodationInfoRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<AccommodationInfoDTO> GetAccommodationInfoInfo()
        {
            return _db.AccommodationInfoes.Project().To<AccommodationInfoDTO>();
        }

        public AccommodationInfoDTO GetAccommodationInfoById(int accommodationId)
        {
            var accommodation = _db.AccommodationInfoes.Find(accommodationId);
            if (accommodation == null) return null;
            else return MapperExtension.mapper.Map<AccommodationInfo, AccommodationInfoDTO>(accommodation);
        }

        public IEnumerable<AccommodationInfoDTO> GetAccommodationInfoByConferenceId(int id)
        {
            var infos = _db.AccommodationInfoes.Where(info => info.ConferenceId == id);
            foreach (var accommodation in infos)
            {
                yield return MapperExtension.mapper.Map<AccommodationInfo, AccommodationInfoDTO>(accommodation);
            }
        }

        public void AddAccommodationInfo(AccommodationInfoDTO accommodationDTO)
        {
            var accommodation = MapperExtension.mapper.Map<AccommodationInfoDTO, AccommodationInfo>(accommodationDTO);
            _db.AccommodationInfoes.Add(accommodation);
            _db.SaveChanges();
        }

        public void EditAccommodationInfo(AccommodationInfoDTO accommodationDTO)
        {
            var accommodation = MapperExtension.mapper.Map<AccommodationInfoDTO, AccommodationInfo>(accommodationDTO);
            _db.Entry(_db.AccommodationInfoes.Find(accommodationDTO.AccommodationInfoId)).CurrentValues.SetValues(accommodation);
            _db.SaveChanges();

        }

        public void DeleteAccommodationInfo(int accommodationId)
        {
            var accommodation = _db.AccommodationInfoes.Find(accommodationId);
            _db.AccommodationInfoes.Remove(accommodation);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
