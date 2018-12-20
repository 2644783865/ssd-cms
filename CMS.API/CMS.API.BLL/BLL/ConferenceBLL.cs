using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Program;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.BLL.BLL
{
    public class ConferenceBLL : IConferenceBLL
    {
        private IConferenceRepository _repository = new ConferenceRepository();
        private IEventRepository _eventRepository = new EventRepository();
        private ISessionRepository _sessionRepository = new SessionRepository();

        public IEnumerable<ConferenceDTO> GetConferences()
        {
            try
            {
                return _repository.GetConferences();
            }
            catch
            {
                return null;
            }
        }

        public ConferenceDTO GetConferenceById(int id)
        {
            try
            {
                var conference = _repository.GetConferenceById(id);
                if (conference == null) return null;
                return conference;
            }
            catch
            {
                return null;
            }
        }

        public bool AddConference(ConferenceDTO conference)
        {
            try
            {
                _repository.AddConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditConference(ConferenceDTO conference)
        {
            try
            {
                _repository.EditConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteConference(int conferenceId)
        {
            try
            {
                _repository.DeleteConference(conferenceId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public ConferenceProgramModel GetConferenceProgram(int conferenceId)
        {
            // not implemented
            var conference = _repository.GetConferenceById(conferenceId);
            var events = _eventRepository.GetEvents(conferenceId).ToList();
            var sessions = _sessionRepository.GetSessions(conferenceId).ToList();
            var specialSessions = _sessionRepository.GetSpecialSessions(conferenceId).ToList();
            var entries = (_eventRepository.GetEvents(conferenceId) as IEnumerable<BaseTimeEntity>).OrderBy(ent => ent.BeginDate).ToList();
            return new ConferenceProgramModel()
            {
                Conference = conference,
                Entries = entries,
                Events = events,
                Sessions = sessions,
                SpecialSessions = specialSessions
            };
        }
    }
}
