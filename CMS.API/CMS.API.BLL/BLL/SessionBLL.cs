﻿using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.BE.Models.Session;
using System;
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

        public Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end, int eventId)
        {
            Response res = new Response();
            // Function checks, whether a new session/special session will overlap with a existing event/session/special session.
            // If there is an overlapping, the function returns a response with the message what the overlapping items are and the status true.
            // If there is no overlapping, the message will be empty and the staus will be false.
            try
            {
                bool resSession = _repository.CheckSessions(conferenceId, begin, end);
                bool resSpecial = _repository.CheckSpecialSessions(conferenceId, begin, end);
                bool resEvent = _repository.CheckEvents(conferenceId, begin, end, eventId);

                if (resSession == false && resSpecial == false && resEvent == false)
                {
                    res.Message = "";
                    res.Status = false;
                }
                else if (resSession == false && resSpecial == false && resEvent == true)
                {
                    res.Message = "Overlapping with Event.";
                    res.Status = true;
                }
                else if (resSession == false && resSpecial == true && resEvent == false)
                {
                    res.Message = "Overlapping with SpecialSession.";
                    res.Status = true;
                }
                else if (resSession == true && resSpecial == false && resEvent == false)
                {
                    res.Message = "Overlapping with Session.";
                    res.Status = true;
                }
                else if (resSession == true && resSpecial == true && resEvent == false)
                {
                    res.Message = "Overlapping with Session and SpecialSession.";
                    res.Status = true;
                }
                else if (resSession == true && resSpecial == false && resEvent == true)
                {
                    res.Message = "Overlapping with Session and Event.";
                    res.Status = true;
                }
                else if (resSession == false && resSpecial == true && resEvent == true)
                {
                    res.Message = "Overlapping with SpecialSession and Event.";
                    res.Status = true;
                }
                else
                {
                    res.Message = "Overlapping with Session, SpecialSession and Event.";
                    res.Status = true;
                }
            }
            catch
            {
                return null;
            }
            return res;
        }
        
        public Response CheckOverlappingSessionForChairman(int chairId, DateTime beginDate, DateTime endDate, int sessionId, int specialSessionId)
        {
            Response res = new Response();
            try
            {
                bool resSession = _repository.CheckSessionForChair(chairId, beginDate, endDate, sessionId);
                bool resSpecial = _repository.CheckSpecialSessionForChair(chairId, beginDate, endDate, specialSessionId);

                if (resSession == false && resSpecial == false)
                {
                    res.Message = "";
                    res.Status = false;
                }
                else if (resSession == true && resSpecial == false)
                {
                    res.Message = "Chair is already assigned to Session.";
                    res.Status = true;
                }
                else if (resSession == false && resSpecial == true)
                {
                    res.Message = "Chair is already assiged tp Special Session.";
                    res.Status = true;
                }
                else
                {
                    res.Message = "Chair is already assiged to Session and to Special Session.";
                    res.Status = true;
                }
            }
            catch
            {
                return null;
            }
            return res;
        }

        public IEnumerable<SessionDTO> GetSessions(int conferenceID)
        {
            try
            {
                return _repository.GetSessions(conferenceID);
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
                return _repository.GetSpecialSessions(conferenceID);
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

        public SpecialSessionDTO GetSpecialSessionByID(int specialSessionID)
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

        public PresentersListModel GetPresentersList(int? sessionId, int? specialSessionId)
        {
            SessionDTO session = null;
            SpecialSessionDTO specialSession = null;
            List<AccountDTO> presenters = null;

            if (sessionId.HasValue)
            {
                session = _repository.GetSessionById(sessionId.Value);
                presenters = _repository.GetPresentersForSession(sessionId.Value).ToList();
            }
            if (specialSessionId.HasValue)
            {
                specialSession = _repository.GetSpecialSessionById(specialSessionId.Value);
                presenters = _repository.GetPresentersForSpecialSession(specialSessionId.Value).ToList();
            }

            return new PresentersListModel()
            {
                Session = session,
                SpecialSession = specialSession,
                Presenters = presenters
            };
        }
    }
}
