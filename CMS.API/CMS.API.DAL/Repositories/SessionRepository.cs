using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private cmsEntities _db = new cmsEntities();
        private IEventRepository _repository = new EventRepository();

        public IEnumerable<SessionDTO> GetSessions(int conferenceID)
        {
            return _db.Sessions.Where(session => session.ConferenceId == conferenceID).Project().To<SessionDTO>();
        }
        public SessionDTO GetSessionById(int id)
        {
            var session = _db.Sessions.Find(id);
            if (session == null) return null;
            else return MapperExtension.mapper.Map<Session, SessionDTO>(session);
        }

        public void AddSession(SessionDTO sessionDTO)
        {
            var session = MapperExtension.mapper.Map<SessionDTO, Session>(sessionDTO);
            _db.Sessions.Add(session);
            _db.SaveChanges();
        }

        public void EditSession(SessionDTO sessionDTO)
        {
            var session = MapperExtension.mapper.Map<SessionDTO, Session>(sessionDTO);
            _db.Entry(_db.Sessions.Find(sessionDTO.SessionId)).CurrentValues.SetValues(session);
            _db.SaveChanges();
        }

        public void DeleteSession(int sessionId)
        {
            var session = _db.Sessions.Find(sessionId);
            _db.Sessions.Remove(session);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
 
        public bool CheckSessions(int conferenceId, DateTime begin, DateTime end)
        {
            // return false, when no overlapping
            // return true, when overlapping with sessions
            IEnumerable<SessionDTO> sessions = GetSessions(conferenceId);
            foreach (SessionDTO session in sessions)
            {
                if(session.BeginDate < begin && session.EndDate < begin)
                {
                    return false;
                }
                else if(session.BeginDate > begin && session.EndDate > end)
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

        public bool CheckSpecialSessions(int conferenceId, DateTime begin, DateTime end)
        {
            // return false, when no overlapping
            // return true, when overlapping with special sessions
            IEnumerable<SpecialSessionDTO> specials = GetSpecialSessions(conferenceId);
            foreach (SpecialSessionDTO special in specials)
            {
                if (special.BeginDate < begin && special.EndDate < begin)
                {
                    return false;
                }
                else if (special.BeginDate > begin && special.EndDate > end)
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

        public bool CheckEvents(int conferenceId, DateTime begin, DateTime end)
        {
            // return false, when no overlapping
            // return true, when overlapping with events
            IEnumerable<EventDTO> events = _repository.GetEvents(conferenceId);
            foreach (EventDTO even in events)
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
 

        //SpecialSession

        public IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceID)
        {
            return _db.SpecialSessions.Where(specialSession => specialSession.ConferenceId == conferenceID).Project().To<SpecialSessionDTO>();
        }
        public SpecialSessionDTO GetSpecialSessionById(int id)
        {
            var specialSession = _db.SpecialSessions.Find(id);
            if (specialSession == null) return null;
            else return MapperExtension.mapper.Map<SpecialSession, SpecialSessionDTO>(specialSession);
        }

        public void AddSpecialSession(SpecialSessionDTO specialSessionDTO)
        {
            var specialSession = MapperExtension.mapper.Map<SpecialSessionDTO, SpecialSession>(specialSessionDTO);
            _db.SpecialSessions.Add(specialSession);
            _db.SaveChanges();
        }

        public void EditSpecialSession(SpecialSessionDTO specialSessionDTO)
        {
            var specialSession = MapperExtension.mapper.Map<SpecialSessionDTO, SpecialSession>(specialSessionDTO);
            _db.Entry(_db.SpecialSessions.Find(specialSessionDTO.SpecialSessionId)).CurrentValues.SetValues(specialSession);
            _db.SaveChanges();
        }

        public void DeleteSpecialSession(int specialSessionId)
        {
            var specialSession = _db.SpecialSessions.Find(specialSessionId);
            _db.SpecialSessions.Remove(specialSession);
            _db.SaveChanges();
        }

    }
}
