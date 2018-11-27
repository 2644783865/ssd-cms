using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class EventRepository : IEventRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<EventDTO> GetEvents()
        {
            return _db.Events.Project().To<EventDTO>();
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
            _db.Entry(_event).CurrentValues.SetValues(_event);
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
    }
}
