using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    class SessionBLL : ISessionBLL
    {
        private ISessionRepository _repository = new SessionRepository();

        public bool AddSession(SessionDTO sessionId)
        {
            try
            {
                _repository.AddSession(sessionId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSession(int session)
        {
            try
            {
                _repository.DeleteSession(session);
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
    }
}
