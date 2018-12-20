using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class ConferenceCore : IConferenceCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<ConferenceDTO>> GetConferencesAsync()
        {
            var path = $"{Properties.Resources.getConferencesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<ConferenceDTO>>(result.Content);
            }
            return null;
        }

        public async Task<ConferenceDTO> GetConferenceByIdAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getConferenceByIdPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ConferenceDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddConferenceAsync(ConferenceDTO conference)
        {
            var path = Properties.Resources.addConferencePath;
            var result = await _apiHelper.Post(path, conference);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        //not implemented
        public async Task<bool> EditConferenceAsync(ConferenceDTO conference)
        {
            var path = Properties.Resources.editConferencePath;
            var result = await _apiHelper.Put(path, conference);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteConferenceAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.deleteConferencePath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<byte[]> GetConferenceProgramAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getConferenceProgramPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ByteArray>(result.Content).Content;
            }
            return null;
        }

        public async Task<byte[]> GetConferenceScheduleAsync(int accountId, int conferenceId)
        {
            var path = $"{Properties.Resources.getConferenceSchedulePath}?accountId={accountId}&conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ByteArray>(result.Content).Content;
            }
            return null;
        }
        public void Dispose() => _apiHelper.Dispose();
    }
}
