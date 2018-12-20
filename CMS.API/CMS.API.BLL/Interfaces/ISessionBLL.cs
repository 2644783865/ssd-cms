using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
   public interface ISessionBLL
    {
        // Session
        bool AddSession(SessionDTO session);
        bool EditSession(SessionDTO session);
        bool DeleteSession(int sessionId);
        IEnumerable<SessionDTO> GetSessions(int conferenceID);
        SessionDTO GetSessionByID(int sessionID);
        IEnumerable<SessionDTO> GetSessionsForChair(int accountId, int conferenceId);
        Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end);

        // Special Session
        bool AddSpecialSession(SpecialSessionDTO specialSession);
        bool EditSpecialSession(SpecialSessionDTO specialSession);
        bool DeleteSpecialSession(int specialSessionId);
        IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceID);
        SpecialSessionDTO GetSpecialSessionByID(int specialSessionID);
        IEnumerable<SpecialSessionDTO> GetSpecialSessionsForChair(int accountId, int conferenceId);
    }
}
