using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;

namespace CMS.API.BLL.BLL
{
    class SpecialSessionBLL : ISpecialSessionBLL
    {
        private ISessionRepository _repository = new SessionRepository();

        public bool AddSpecialSession(SpecialSessionDTO specialSessionId)
        {
            try
            {
                _repository.AddSpecialSession(specialSessionId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSpecialSession(int specialSession)
        {
            try
            {
                _repository.DeleteSpecialSession(specialSession);
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
