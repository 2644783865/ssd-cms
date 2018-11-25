using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<ConferenceDTO> GetConferences()
        {
            return _db.Conferences.Project().To<ConferenceDTO>();
        }
        public ConferenceDTO GetConferenceById(int id)
        {
            var conference = _db.Conferences.Find(id);
            if (conference == null) return null;
            else return MapperExtension.mapper.Map<Conference, ConferenceDTO>(conference);
        }

        public void AddConference(ConferenceDTO conferenceDTO)
        {
            var conference = MapperExtension.mapper.Map<ConferenceDTO, Conference>(conferenceDTO);
            _db.Conferences.Add(conference);
            _db.SaveChanges();
        }

        public void EditConference(ConferenceDTO conferenceDTO)
        {
            var conference = MapperExtension.mapper.Map<ConferenceDTO, Conference>(conferenceDTO);
            _db.Entry(conference).CurrentValues.SetValues(conference);
            _db.SaveChanges();
        }

        public void DeleteConference(int conferenceId)
        {
            var conference = _db.Conferences.Find(conferenceId);
            _db.Conferences.Remove(conference);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
