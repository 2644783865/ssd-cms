using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class TravelInfoCore : ITravelInfoCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<TravelInfoDTO>> GetTravelInfoAsync()
        {
            var path = $"{Properties.Resources.getTravelInfoPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TravelInfoDTO>>(result.Content);
            }
            return null;
        }

        public async Task<TravelInfoDTO> GetTravelByIdAsync(int travelInfoId)
        {
            var path = $"{Properties.Resources.getTravelByIdPath}?travelid={travelInfoId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<TravelInfoDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<TravelInfoDTO>> GetTravelInfoByConferenceIdAsync(int conferenceid)
        {
            var path = $"{Properties.Resources.getTravelInfoByConferenceId}?conferenceId={conferenceid}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TravelInfoDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> AddTravelAsync(TravelInfoDTO travelInfo)
        {
            var path = Properties.Resources.addTravelPath;
            var result = await _apiHelper.Post(path, travelInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditTravelAsync(TravelInfoDTO travelInfo)
        {
            var path = Properties.Resources.editTravelPath;
            var result = await _apiHelper.Put(path, travelInfo);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteTravelAsync(int travelInfoId)
        {
            var path = $"{Properties.Resources.deleteTravelPath}?travelid={travelInfoId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
