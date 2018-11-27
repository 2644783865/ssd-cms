using CMS.BE.DTO;

namespace CMS.API.BLL.Interfaces
{
    interface ISpecialSession
    {
        bool AddSpecialSession(SpecialSessionDTO specialSession);
        bool EditSpecialSession(SpecialSessionDTO specialSession);
        bool DeleteSpecialSession(int specialSessionId);
    }
}
