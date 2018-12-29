using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class EmergencyInfoBLL : IEmergencyInfoBLL
    {
        private IEmergencyInfoRepository _repository = new EmergencyInfoRepository();

        public IEnumerable<EmergencyInfoDTO> GetEmergencyInfoInfo()
        {
            try
            {
                return _repository.GetEmergencyInfoInfo();
            }
            catch
            {
                return null;
            }
        }

        public EmergencyInfoDTO GetEmergencyInfoById(int id)
        {
            try
            {
                var emergencyinfo = _repository.GetEmergencyInfoById(id);
                if (emergencyinfo == null) return null;
                return emergencyinfo;
            }
            catch
            {
                return null;
            }
        }

        public bool AddEmergencyInfo(EmergencyInfoDTO emergencyinfo)
        {
            try
            {
                _repository.AddEmergencyInfo(emergencyinfo);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditEmergencyInfo(EmergencyInfoDTO emergencyinfo)
        {
            try
            {
                _repository.EditEmergencyInfo(emergencyinfo);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteEmergencyInfo(int emergencyinfoId)
        {
            try
            {
                _repository.DeleteEmergencyInfo(emergencyinfoId);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public EmergencyInfoDTO GetEmergencyInfoByConferenceId(int id)
        {
            try
            {
                return _repository.GetEmergencyInfoByConferenceId(id);
            }
            catch
            {
                return null;
            }
        }
    }
}
