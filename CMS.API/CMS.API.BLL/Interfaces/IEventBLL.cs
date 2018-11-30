using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IEventBLL
    {
        IEnumerable<EventDTO> GetEvents();
        EventDTO GetEventById(int id);
        bool AddEvent(EventDTO eventDTO);
        bool EditEvent(EventDTO eventDTO);
        bool DeleteEvent(int eventId);
    }
}
