using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
   public interface ISessionBLL
    {
        // Session
        bool AddSession(SessionDTO session);
        bool EditSession(SessionDTO session);
        bool DeleteSession(int sessionId);

        // Special Session
        bool AddSpecialSession(SpecialSessionDTO specialSession);
        bool EditSpecialSession(SpecialSessionDTO specialSession);
        bool DeleteSpecialSession(int specialSessionId);
    }
}
