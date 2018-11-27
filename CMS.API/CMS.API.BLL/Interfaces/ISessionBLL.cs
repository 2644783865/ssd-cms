using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface ISessionBLL
    {
        bool AddSession(SessionDTO sessionId);
        bool EditSession(SessionDTO session);
        bool DeleteSession(int session);
    }
}
