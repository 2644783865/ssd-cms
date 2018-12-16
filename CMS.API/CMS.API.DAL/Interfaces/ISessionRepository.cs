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
        void AddSession(SessionDTO sessionDTO);
        void EditSession(SessionDTO sessionDTO);
        void DeleteSession(int sessionId);
        bool CheckSessions(int conferenceId, DateTime begin, DateTime end);
        bool CheckSpecialSessions(int conferenceId, DateTime begin, DateTime end);

        //SpecialSession
        IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceID);
        SpecialSessionDTO GetSpecialSessionById(int id);
        void AddSpecialSession(SpecialSessionDTO specialSessionDTO);
        void EditSpecialSession(SpecialSessionDTO specialSessionDTO);
        void DeleteSpecialSession(int specialSessionId);
    }
}
