using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IEventCore : IDisposable
    {
        Task<List<EventDTO>> GetEventsAsync(int ConferenceId);
        Task<EventDTO> GetEventByIdAsync(int EventID);
        Task<bool> AddEventAsync(EventDTO eventDTO);
        Task<bool> EditEventAsync(EventDTO eventDTO);
        Task<bool> DeleteEventAsync(int EventID);
        Task<List<RoomDTO>> GetListRoomsAsync(int ConferenceId);
        Task<Response> CheckOverlappingEventAsync(int conferenceId, DateTime begin, DateTime end);
    }
}