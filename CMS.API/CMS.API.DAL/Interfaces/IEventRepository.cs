using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IEventRepository : IDisposable
    {
        IEnumerable<EventDTO> GetEvents(int conferenceId);
        EventDTO GetEventById(int id);
        void AddEvent(EventDTO eventDTO);
        void EditEvent(EventDTO eventDTO);
        void DeleteEvent(int eventId);
    }
}