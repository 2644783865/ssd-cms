using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IAwardBLL
    {
        IEnumerable<AwardDTO> GetAwards();
        bool GetAwardById(int id);
        AwardDTO GetAwardForSession(int? sessionId, int? specialSessionId);
        bool AddAward(AwardDTO award);
        bool EditAward(AwardDTO award);
        bool DeleteAward(int AwardId);
        bool CheckIfPresentationHasAward(int presentationId);
        bool DeleteAssignmentAwardToPresentation(int presentationId);
    }
}
