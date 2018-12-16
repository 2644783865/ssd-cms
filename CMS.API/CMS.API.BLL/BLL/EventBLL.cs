using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class EventBLL: IEventBLL
    {
        private IEventRepository _repository = new EventRepository();

        public IEnumerable<EventDTO> GetEvents(int conferenceId)
        {
            try
            {
                return _repository.GetEvents(conferenceId);
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
        public Response CheckOverlappingEvent(int conferenceId, DateTime begin, DateTime end)
        {
            Response res = new Response();
            // Function checks, whether a new event will overlap with a existing event session.
            // If there is an overlapping, the function returns a response with the message what the overlapping items are and the status true.
            // If there is no overlapping, the message will be empty and the staus will be false.
            try
            {
                bool resEve = _repository.CheckEvents(conferenceId, begin, end);

                if (resEve == true)
                {
                    res.Message = "Overlapping with other event";
                    res.Status = true;
                }
                else
                {
                    res.Message = "";
                    res.Status = false;
                }
            }
            catch
            {
                return null;
            }
            return res;
        }
    }
}
