﻿using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class EventCore : IEventCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<EventDTO>> GetEventsAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getEventsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<EventDTO>>(result.Content);
            }
            return null;
        }

        public async Task<EventDTO> GetEventByIdAsync(int eventId)
        {
            var path = $"{Properties.Resources.getEventByIdPath}?eventId={eventId}";
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

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var path = $"{Properties.Resources.deleteEventPath}?eventId={eventId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<List<RoomDTO>> GetListRoomsAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getListRoomsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<RoomDTO>>(result.Content);
            }
            return null;
        }


        public void Dispose() => _apiHelper.Dispose();
    }
}

}
