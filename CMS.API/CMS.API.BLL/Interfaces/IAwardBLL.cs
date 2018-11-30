using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IAwardBLL
    {
        IEnumerable<AwardDTO> GetAwards();
        AwardDTO GetAwardById(int id);
        bool AddAward(AwardDTO award);
        bool EditAward(AwardDTO award);
        bool DeleteAward(int awardId);
    }
}
