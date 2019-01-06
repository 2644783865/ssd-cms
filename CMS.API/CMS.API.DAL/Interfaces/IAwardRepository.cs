using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAwardRepository : IDisposable
    {
        IEnumerable<AwardDTO> GetAwards();
        AwardDTO GetAwardById(int id);
        AwardDTO GetAwardForSession(int? sessionId, int? specialSessionId);
        void AddAward(AwardDTO awardDTO);
        void EditAward(AwardDTO awardDTO);
        void DeleteAward(int AwardId);
        bool CheckIfPresentationHasAward(int presentationId);
        void DeleteAssignmentAwardToPresentation(int presentationId);
    }
}