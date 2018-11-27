using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface ISessionBLL
    {
        bool AddSession(SessionDTO session);
        bool EditSession(SessionDTO session);
        bool DeleteSession(int sessionId);
    }
}
