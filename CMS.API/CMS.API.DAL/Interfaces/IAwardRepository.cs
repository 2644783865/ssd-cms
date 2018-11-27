using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAwardRepository : IDisposable
    {
        IEnumerable<AwardDTO> GetAwards();
        AwardDTO GetAwardById(int id);
        void AddAward(AwardDTO awardDTO);
        void EditAward(AwardDTO awardDTO);
        void DeleteAward(int awardId);
    }
}