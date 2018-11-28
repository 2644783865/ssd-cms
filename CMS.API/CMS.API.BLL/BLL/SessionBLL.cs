using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

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
    }
}
