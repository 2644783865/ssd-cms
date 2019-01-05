using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.BE.Models.Session;
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
        IEnumerable<SessionDTO> GetSessions(int conferenceId);
        SessionDTO GetSessionByID(int sessionId);
        Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end, int eventId);
        Response CheckOverlappingSessionForChairman(int chairId, DateTime beginDate, DateTime endDate, int sessionId, int specialSessionId);

        // Special Session
        bool AddSpecialSession(SpecialSessionDTO specialSession);
        bool EditSpecialSession(SpecialSessionDTO specialSession);
        bool DeleteSpecialSession(int specialSessionId);
        IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceId);
        SpecialSessionDTO GetSpecialSessionByID(int specialSessionId);
        PresentersListModel GetPresentersList(int? sessionId, int? specialSessionId);
    }
}
