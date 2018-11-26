using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class EmergencyInfoRepository : IEmergencyInfoRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<EmergencyInfoDTO> GetEmergencyInfoInfo()
        {
            return _db.EmergencyInfoes.Project().To<EmergencyInfoDTO>();
        }

        public EmergencyInfoDTO GetEmergencyInfoById(int emergencyInfoId)
        {
            var emergencyInfo = _db.EmergencyInfoes.Find(emergencyInfoId);
            if (emergencyInfo == null) return null;
            else return MapperExtension.mapper.Map<EmergencyInfo, EmergencyInfoDTO>(emergencyInfo);
        }

        public void AddEmergencyInfo(EmergencyInfoDTO emergencyInfoDTO)
        {
            var emergencyInfo = MapperExtension.mapper.Map<EmergencyInfoDTO, EmergencyInfo>(emergencyInfoDTO);
            _db.EmergencyInfoes.Add(emergencyInfo);
            _db.SaveChanges();
        }

        public void EditEmergencyInfo(EmergencyInfoDTO emergencyInfoDTO)
        {
            var emergencyInfo = MapperExtension.mapper.Map<EmergencyInfoDTO, EmergencyInfo>(emergencyInfoDTO);
            _db.Entry(emergencyInfo).CurrentValues.SetValues(emergencyInfo);
            _db.SaveChanges();

        }

        public void DeleteEmergencyInfo(int emergencyInfoId)
        {
            var emergencyInfo = _db.EmergencyInfoes.Find(emergencyInfoId);
            _db.EmergencyInfoes.Remove(emergencyInfo);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
