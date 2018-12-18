using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class EventCore : IEventCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<EventDTO>> GetEventsAsync(int ConferenceId)
        {
            var path = $"{Properties.Resources.getEventsPath}?ConferenceId={ConferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<EventDTO>>(result.Content);
            }
            return null;
        }

        public async Task<EventDTO> GetEventByIdAsync(int EventID)
        {
            var path = $"{Properties.Resources.getEventByIdPath}?eventId={EventID}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<EventDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddEventAsync(EventDTO eventDTO)
        {
            var path = Properties.Resources.addEventPath;
            var result = await _apiHelper.Post(path, eventDTO);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<bool> EditEventAsync(EventDTO eventDTO)
        {
            var path = Properties.Resources.editEventPath;
            var result = await _apiHelper.Put(path, eventDTO);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteEventAsync(int EventID)
        {
            var path = $"{Properties.Resources.deleteEventPath}?eventID={EventID}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<List<RoomDTO>> GetListRoomsAsync(int ConferenceId)
        {
            var path = $"{Properties.Resources.getListRoomsPath}?conferenceId={ConferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoomDTO>>(result.Content);
            }
            return null;
        }

        public async Task<Response> CheckOverlappingEventAsync(int conferenceId, DateTime begin, DateTime end)
        {
            var path = $"{Properties.Resources.checkOverlappingEventPath}?conferenceId={conferenceId}&begin={begin}&end={end}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<Response>(result.Content);
            }
            else return null;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
