using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface ISessionRepository : IDisposable
    {
        //Session
        IEnumerable<SessionDTO> GetSessions(int conferenceID);
        SessionDTO GetSessionById(int id);
        IEnumerable<SessionDTO> GetSessionsByChairId(int chairId);
        void AddSession(SessionDTO sessionDTO);
        void EditSession(SessionDTO sessionDTO);
        void DeleteSession(int sessionId);
        bool CheckSessions(int conferenceId, DateTime begin, DateTime end);
        bool CheckSpecialSessions(int conferenceId, DateTime begin, DateTime end);
        bool CheckEvents(int conferenceId, DateTime begin, DateTime end, int eventId);
        IEnumerable<SessionDTO> GetSessionsForConferenceWithBaseEntryAttributes(int conferenceId);
        IEnumerable<SessionDTO> GetSessionsForConferenceAndChairWithBaseEntryAttributes(int accountId, int conferenceId);
        bool CheckSessionForChair(int chairId, DateTime beginDate, DateTime endDate, int sessionId);
        bool CheckSpecialSessionForChair(int chairId, DateTime beginDate, DateTime endDate, int specialSessionId);

        //SpecialSession
        IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceID);
        SpecialSessionDTO GetSpecialSessionById(int id);
        IEnumerable<SpecialSessionDTO> GetSpecialSessionsByChairId(int chairId);
        void AddSpecialSession(SpecialSessionDTO specialSessionDTO);
        void EditSpecialSession(SpecialSessionDTO specialSessionDTO);
        void DeleteSpecialSession(int specialSessionId);
        IEnumerable<SpecialSessionDTO> GetSpecialSessionsForConferenceWithBaseEntryAttributes(int conferenceId);
        IEnumerable<SpecialSessionDTO> GetSpecialSessionsForConferenceAndChairWithBaseEntryAttributes(int accountId, int conferenceId);
        IEnumerable<AccountDTO> GetPresentersForSession(int sessionId);
        IEnumerable<AccountDTO> GetPresentersForSpecialSession(int specialSessionId);
    }
}
