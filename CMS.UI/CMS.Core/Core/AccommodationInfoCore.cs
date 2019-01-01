using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class AccommodationInfoCore : IAccommodationInfoCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<AccommodationInfoDTO>> GetAccommodationInfoInfoAsync()
        {
            var path = $"{Properties.Resources.getAccommodationInfoInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AccommodationInfoDTO>>(result.Content);
            }
            return null;
        }

        public async Task<AccommodationInfoDTO> GetAccommodationInfoByIdAsync(int accommodationInfoId)
        {
            var path = $"{Properties.Resources.getAccommodationInfoByIdPath}?accommodationInfoId={accommodationInfoId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<AccommodationInfoDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<AccommodationInfoDTO>> GetAccommodationInfoByConferenceIdAsync(int conferenceid)
        {
            var path = $"{Properties.Resources.getAccomodationInfoByConferenceIdPath}?conferenceId={conferenceid}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AccommodationInfoDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> AddAccommodationInfoAsync(AccommodationInfoDTO accommodationInfo)
        {
            var path = Properties.Resources.addAccommodationInfoPath;
            var result = await _apiHelper.Post(path, accommodationInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditAccommodationInfoAsync(AccommodationInfoDTO accommodationInfo)
        {
            var path = Properties.Resources.editAccommodationInfoPath;
            var result = await _apiHelper.Put(path, accommodationInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteAccommodationInfoAsync(int accommodationInfoId)
        {
            var path = $"{Properties.Resources.deleteAccommodationInfoPath}?accommodationInfoId={accommodationInfoId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
