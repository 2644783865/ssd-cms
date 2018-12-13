﻿using CMS.API.BLL.Interfaces;
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
        /* Functions CheckSessions, CheckSpecialSessions, CheckEvents not implemented in DAL 
                public Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end)
                {
                    Response res = new Response();
                    // Function checks, whether a new event/session/special session will overlap with anything.
                    // If there is an overlapping, the function returns a response with the message what the overlapping items are and the status true.
                    // If there is no overlapping, the message will be empty and the staus will be false.
                    try
                    {
                        bool resSession = _repository.CheckSessions(int conferenceId, DateTime begin, DateTime end);
                        bool resSpecial = _repository.CheckSpecialSessions(int conferenceId, DateTime begin, DateTime end);
                        bool resEvent = _repository.CheckEvents(int conferenceId, DateTime begin, DateTime end);

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
                        else if(resSession == true && resSpecial == true && resEvent == false)
                        {
                            res.Message = "Overlapping with Session, SpecialSession.";
                            res.Status = true;
                        }
                        else if (resSession == true && resSpecial == false && resEvent == true)
                        {
                            res.Message = "Overlapping with Session, Event.";
                            res.Status = true;
                        }
                        else if (resSession == false && resSpecial == true && resEvent == true)
                        {
                            res.Message = "Overlapping with SpecialSession, Event";
                            res.Status = true;
                        }
                        else
                        {
                            res.Message = "Overlapping with Session, SpecialSession, Event.";
                            res.Status = true;
                        }
                    }
                    catch
                    {
                        return null;
                    }
                    return res;
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

        public Response CheckOverlappingSession(int conferenceId, DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
