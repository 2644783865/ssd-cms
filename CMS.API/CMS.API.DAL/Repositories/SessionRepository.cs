using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<SessionDTO> GetSessionsByChairId(int chairId)
        {
            return _db.Sessions.Where(session => session.ChairId == chairId).Project().To<SessionDTO>();
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
                if ((DateTime.Compare(session.BeginDate, begin) > 0) && (DateTime.Compare(session.BeginDate, end) > 0))
                {
                    return false;
                }
                else if ((DateTime.Compare(session.BeginDate, begin) < 0) && (DateTime.Compare(session.EndDate, begin) < 0))
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
                if ((DateTime.Compare(special.BeginDate, begin) > 0) && (DateTime.Compare(special.BeginDate, end) > 0))
                {
                    return false;
                }
                else if ((DateTime.Compare(special.BeginDate, begin) < 0) && (DateTime.Compare(special.EndDate, begin) < 0))
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
            IEnumerable<EventDTO> eve = _repository.GetEvents(conferenceId);
            foreach (EventDTO even in eve)
            {
                if ((DateTime.Compare(even.BeginDate, begin) > 0) && (DateTime.Compare(even.BeginDate, end) >= 0))
                {
                    return false;
                }
                else if ((DateTime.Compare(even.BeginDate, begin) < 0) && (DateTime.Compare(even.EndDate, begin) <= 0))
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

        public IEnumerable<SessionDTO> GetSessionsForConferenceWithBaseEntryAttributes(int conferenceId)
        {
            return _db.Database.SqlQuery<SessionDTO>("SELECT Session.BeginDate, Session.EndDate, Session.Title, " +
                "Session.Description, Room.Code AS RoomCode, Building.Name AS BuildingName, Account.Name AS AccountName " +
                "FROM Session " +
                "INNER JOIN Room ON Session.RoomId = Room.RoomID " +
                "INNER JOIN Building ON Room.BuildingID = Building.BuildingID " +
                "INNER JOIN Account ON Session.ChairId = Account.AccountId " +
                "WHERE ConferenceId = @ConferenceId", new SqlParameter("ConferenceId", conferenceId));
        }

        public IEnumerable<SessionDTO> GetSessionsForConferenceAndChairWithBaseEntryAttributes(int accountId, int conferenceId)
        {
            return _db.Database.SqlQuery<SessionDTO>("SELECT Session.BeginDate, Session.EndDate, Session.Title, " +
                "Session.Description, Room.Code AS RoomCode, Building.Name AS BuildingName, Account.Name AS AccountName " +
                "FROM Session " +
                "INNER JOIN Room ON Session.RoomId = Room.RoomID " +
                "INNER JOIN Building ON Room.BuildingID = Building.BuildingID " +
                "INNER JOIN Account ON Session.ChairId = Account.AccountId " +
                "WHERE ConferenceId = @ConferenceId AND ChairId = @ChairId", new SqlParameter("ConferenceId", conferenceId),
                new SqlParameter("ChairId", accountId));
        }

        public bool CheckSessionForChair(int chairId, DateTime beginDate, DateTime endDate)
        {
            IEnumerable<SessionDTO> sessions = GetSessionsByChairId(chairId);
            foreach (SessionDTO session in sessions)
            {
                if ((DateTime.Compare(session.BeginDate, beginDate) > 0) && (DateTime.Compare(session.BeginDate, endDate) > 0))
                {
                    return false;
                }
                else if ((DateTime.Compare(session.BeginDate, beginDate) < 0) && (DateTime.Compare(session.EndDate, beginDate) < 0))
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

        public bool CheckSpecialSessionForChair(int chairId, DateTime beginDate, DateTime endDate)
        {
            IEnumerable<SpecialSessionDTO> specials = GetSpecialSessionsByChairId(chairId);
            foreach (SpecialSessionDTO session in specials)
            {
                if ((DateTime.Compare(session.BeginDate, beginDate) > 0) && (DateTime.Compare(session.BeginDate, endDate) > 0))
                {
                    return false;
                }
                else if ((DateTime.Compare(session.BeginDate, beginDate) < 0) && (DateTime.Compare(session.EndDate, beginDate) < 0))
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

        public IEnumerable<SpecialSessionDTO> GetSpecialSessionsByChairId(int chairId)
        {
            return _db.SpecialSessions.Where(session => session.ChairId == chairId).Project().To<SpecialSessionDTO>();
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

        public IEnumerable<SpecialSessionDTO> GetSpecialSessionsForConferenceAndChairWithBaseEntryAttributes(int accountId, int conferenceId)
        {
            return _db.Database.SqlQuery<SpecialSessionDTO>("SELECT SpecialSession.BeginDate, SpecialSession.EndDate, " +
                "SpecialSession.Title, SpecialSession.Description, Room.Code AS RoomCode, Building.Name AS BuildingName, " +
                "Account.Name AS AccountName " +
                "FROM SpecialSession " +
                "INNER JOIN Room ON SpecialSession.RoomId = Room.RoomID " +
                "INNER JOIN Building ON Room.BuildingID = Building.BuildingID " +
                "INNER JOIN Account ON SpecialSession.ChairId = Account.AccountId " +
                "WHERE ConferenceId = @ConferenceId AND ChairId = @ChairId", new SqlParameter("ConferenceId", conferenceId), 
                new SqlParameter("ChairId", accountId));
        }

        public IEnumerable<SpecialSessionDTO> GetSpecialSessionsForConferenceWithBaseEntryAttributes(int conferenceId)
        {
            return _db.Database.SqlQuery<SpecialSessionDTO>("SELECT SpecialSession.BeginDate, SpecialSession.EndDate, " +
                "SpecialSession.Title, SpecialSession.Description, Room.Code AS RoomCode, Building.Name AS BuildingName, " +
                "Account.Name AS AccountName " +
                "FROM SpecialSession " +
                "INNER JOIN Room ON SpecialSession.RoomId = Room.RoomID " +
                "INNER JOIN Building ON Room.BuildingID = Building.BuildingID " +
                "INNER JOIN Account ON SpecialSession.ChairId = Account.AccountId " +
                "WHERE ConferenceId = @ConferenceId", new SqlParameter("ConferenceId", conferenceId));
        }
    }
}
