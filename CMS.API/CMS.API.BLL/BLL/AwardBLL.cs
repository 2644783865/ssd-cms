using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
   public class AwardBLL : IAwardBLL
    {
        private IAwardRepository _repository = new AwardRepository();

        public IEnumerable<AwardDTO> GetAwards()
        {
            try
            {
                return _repository.GetAwards();
            }
            catch
            {
                return null;
            }
        }

        public bool AddAward(AwardDTO award)
        {
            try
            {
                _repository.AddAward(award);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public AwardDTO GetAwardById(int id)
        {
            try
            {
                var task = GetAwardById(id);
                if (task == null) return null;
                return task;
            }
            catch
            {
                return null;
            }
        }

        public bool EditAward(AwardDTO award)
        {
            try
            {
                _repository.EditAward(award);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteAward(int awardId)
        {
            try
            {
                _repository.DeleteAward(awardId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}