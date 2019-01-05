using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class EmergencyInfoCore : IEmergencyInfoCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<EmergencyInfoDTO>> GetEmergencyInfoInfoAsync()
        {
            var path = $"{Properties.Resources.getEmergencyInfoInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<EmergencyInfoDTO>>(result.Content);
            }
            return null;
        }

        public async Task<EmergencyInfoDTO> GetEmergencyInfoByIdAsync(int emergencyInfoId)
        {
            var path = $"{Properties.Resources.getEmergencyInfoByIdPath}?emergencyInfoId={emergencyInfoId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<EmergencyInfoDTO>(result.Content);
            }
            else return null;
        }

        public async Task<EmergencyInfoDTO> GetEmergencyInfoByConferenceIdAsync(int conferenceid)
        {
            var path = $"{Properties.Resources.getEmergencyInfoByConferenceIdPath}?conferenceId={conferenceid}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<EmergencyInfoDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddEmergencyInfoAsync(EmergencyInfoDTO emergencyInfo)
        {
            var path = Properties.Resources.addEmergencyInfoPath;
            var result = await _apiHelper.Post(path, emergencyInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditEmergencyInfoAsync(EmergencyInfoDTO emergencyInfo)
        {
            var path = Properties.Resources.editEmergencyInfoPath;
            var result = await _apiHelper.Put(path, emergencyInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteEmergencyInfoAsync(int emergencyInfoId)
        {
            var path = $"{Properties.Resources.deleteEmergencyInfoPath}?emergencyId={emergencyInfoId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
