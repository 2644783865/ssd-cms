using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    class EventBLL: IEventBLL
    {
        private IEventRepository _repository = new EventRepository();

        public IEnumerable<EventDTO> GetEvents()
        {
            try
            {
                return _repository.GetEvents();
            }
            catch
            {
                return null;
            }
        }
        public EventDTO GetEventById(int id)
        {
            try
            {
                var eventDTO = GetEventById(id);
                if (eventDTO == null) return null;
                return eventDTO;
            }
            catch
            {
                return null;
            }
        }
        public bool AddEvent(EventDTO eventDTO)
        {
            try
            {
                _repository.AddEvent(eventDTO);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditEvent(EventDTO eventDTO)
        {
            try
            {
                _repository.EditEvent(eventDTO);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteEvent(int eventId)
        {
            try
            {
                _repository.DeleteEvent(eventId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
