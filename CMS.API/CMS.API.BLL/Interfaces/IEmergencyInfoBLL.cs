using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IEmergencyInfoBLL
    {
        IEnumerable<EmergencyInfoDTO> GetEmergencyInfoInfo();
        EmergencyInfoDTO GetEmergencyInfoById(int id);
        bool AddEmergencyInfo(EmergencyInfoDTO emergencyinfo);
        bool EditEmergencyInfo(EmergencyInfoDTO emergencyinfo);
        bool DeleteEmergencyInfo(int emergencyinfoId);
        EmergencyInfoDTO GetEmergencyInfoByConferenceId(int id);
    }
}