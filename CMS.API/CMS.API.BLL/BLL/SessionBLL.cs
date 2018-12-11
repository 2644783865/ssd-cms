using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.BLL.BLL
{
    public class SessionBLL : ISessionBLL
    {
        private ISessionRepository _repository = new SessionRepository();

        // Session
        public bool AddSession(SessionDTO session)
        {
            try
            {
                _repository.AddSession(session);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSession(int sessionId)
        {
            try
            {
                _repository.DeleteSession(sessionId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSession(SessionDTO session)
        {
            try
            {
                _repository.EditSession(session);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // Special Session
        public bool AddSpecialSession(SpecialSessionDTO specialSession)
        {
            try
            {
                _repository.AddSpecialSession(specialSession);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSpecialSession(int specialSessionId)
        {
            try
            {
                _repository.DeleteSpecialSession(specialSessionId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSpecialSession(SpecialSessionDTO specialSession)
        {
            try
            {
                _repository.EditSpecialSession(specialSession);
            }
            catch
            {
                return false;
            }
            return true;
        }
 /* not ready yet
        public Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end)
        {
            try
            {
                if (_repository.CheckSession == true)
                {
                    Response res = 
                }
                else
                {

                }
            }
            catch
            {
                return null;
            }
        }
*/
        public IEnumerable<SessionDTO> GetSessions(int conferenceID)
        {
            try
            {
                return _repository.GetSessions(conferenceID) as List<SessionDTO>;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<SpecialSessionDTO> GetSpecialSessions(int conferenceID)
        {
            try
            {
                return _repository.GetSpecialSessions(conferenceID) as List<SpecialSessionDTO>;
            }
            catch
            {
                return null;
            }
        }

        public SessionDTO GetSessionByID(int sessionID)
        {
            try
            {
                return _repository.GetSessionById(sessionID);
            }
            catch
            {
                return null;
            }

        }

        public SpecialSessionDTO GetSpeccialSessionByID(int specialSessionID)
        {
            try
            {
                return _repository.GetSpecialSessionById(specialSessionID);
            }
            catch
            {
                return null;
            }
        }
        
    }
}
