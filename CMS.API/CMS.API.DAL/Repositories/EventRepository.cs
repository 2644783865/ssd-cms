using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<EventDTO> GetEvents(int conferenceId)
        {
            return _db.Events.Where(events => events.ConferenceId == conferenceId).Project().To<EventDTO>();
        }

        public EventDTO GetEventById(int id)
        {
            var _event = _db.Events.Find(id);
            if (_event == null) return null;
            else return MapperExtension.mapper.Map<Event, EventDTO>(_event);
        }

        public void AddEvent(EventDTO eventDTO)
        {
            var _event = MapperExtension.mapper.Map<EventDTO, Event>(eventDTO);
            _db.Events.Add(_event);
            _db.SaveChanges();
        }

        public void EditEvent(EventDTO eventDTO)
        {
            var _event = MapperExtension.mapper.Map<EventDTO, Event>(eventDTO);
            _db.Entry(_db.Events.Find(eventDTO.EventID)).CurrentValues.SetValues(_event);
            _db.SaveChanges();
        }

        public void DeleteEvent(int EventId)
        {
            var _event = _db.Events.Find(EventId);
            _db.Events.Remove(_event);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool CheckEvents(int conferenceId, DateTime begin, DateTime end)
        {
            // return false, when no overlapping
            // return true, when overlapping with events
            IEnumerable<EventDTO> eve = GetEvents(conferenceId);
            foreach (EventDTO even in eve)
            {
                if (even.BeginDate < begin && even.EndDate < begin)
                {
                    return false;
                }
                else if (even.BeginDate > begin && even.EndDate > end)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
