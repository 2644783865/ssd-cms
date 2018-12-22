using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IEmergencyInfoRepository : IDisposable
    {
        IEnumerable<EmergencyInfoDTO> GetEmergencyInfoInfo();
        EmergencyInfoDTO GetEmergencyInfoById(int id);
        EmergencyInfoDTO GetEmergencyInfoByConferenceId(int id);
        void AddEmergencyInfo(EmergencyInfoDTO emergencyInfoDTO);
        void EditEmergencyInfo(EmergencyInfoDTO emergencyInfoDTO);
        void DeleteEmergencyInfo(int emergencyInfoId);
    }
}
