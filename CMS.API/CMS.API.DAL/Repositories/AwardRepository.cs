using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

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

        public void DeleteAward(int awardId)
        {
            var award = _db.Awards.Find(awardId);
            _db.Awards.Remove(award);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
