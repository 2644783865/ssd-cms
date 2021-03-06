﻿using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<AwardDTO> GetAwards()
        {
            return _db.Awards.Project().To<AwardDTO>();
        }

        public AwardDTO GetAwardById(int id)
        {
            var award = _db.Awards.Find(id);
            if (award == null) return null;
            else return MapperExtension.mapper.Map<Award, AwardDTO>(award);
        }

        public AwardDTO GetAwardForSession(int? sessionId, int? specialSessionId)
        {
            Award award = null;
            if (sessionId.HasValue) award = _db.Awards.Where(a => a.Presentation.SessionId == sessionId.Value).FirstOrDefault();
            if (specialSessionId.HasValue) award = _db.Awards.Where(a => a.Presentation.SpecialSessionId == specialSessionId.Value).FirstOrDefault();
            if (award == null) return null;
            else return MapperExtension.mapper.Map<Award, AwardDTO>(award);
        }

        public void AddAward(AwardDTO awardDTO)
        {
            var award = MapperExtension.mapper.Map<AwardDTO, Award>(awardDTO);
            _db.Awards.Add(award);
            _db.SaveChanges();
        }

        public void EditAward(AwardDTO awardDTO)
        {
            var award = MapperExtension.mapper.Map<AwardDTO, Award>(awardDTO);
            _db.Entry(_db.Awards.Find(awardDTO.AwardId)).CurrentValues.SetValues(award);
            _db.SaveChanges();
        }

        public void DeleteAward(int AwardId)
        {
            var award = _db.Awards.Find(AwardId);
            _db.Awards.Remove(award);
            _db.SaveChanges();
        }

        public bool CheckIfPresentationHasAward(int presentationId)
        {
            if (GetAwards() != null)
            {
                if (presentationId == GetAwards().First().PresentationId)
                    return true;
                else return false;
            }
            else return false;
        }

        public void DeleteAssignmentAwardToPresentation(int presentationId)
        {
            DeleteAward(presentationId);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
