using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IEventBLL
    {
        IEnumerable<EventDTO> GetEvents(int conferenceId);
        EventDTO GetEventById(int id);
        bool AddEvent(EventDTO eventDTO);
        bool EditEvent(EventDTO eventDTO);
        bool DeleteEvent(int eventId);
        Response CheckOverlappingEvent(int conferenceId, DateTime begin, DateTime end);
    }
}
