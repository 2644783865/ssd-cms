using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface ISpecialSessionBLL
    {
        bool AddSpecialSession(SpecialSessionDTO specialSessionId);
        bool EditSpecialSession(SpecialSessionDTO specialSession);
        bool DeleteSpecialSession(int specialSession);
    }
}
