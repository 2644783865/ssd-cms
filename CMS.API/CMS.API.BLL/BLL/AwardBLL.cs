using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System;
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

        public bool GetAwardById(int id)
        {
            try
            {
                _repository.GetAwardById(id);
            }
            catch
            {
                return false;
            }
            return true;
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

        public bool DeleteAward(int AwardId)
        {
            try
            {
                _repository.DeleteAward(AwardId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool CheckIfPresentationHasAward(int presentationId)
        {
            try
            {
                _repository.CheckIfPresentationHasAward(presentationId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAssignmentAwardToPresentation(int presentationId)
        {
            try
            {
                _repository.DeleteAssignmentAwardToPresentation(presentationId);
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static implicit operator AwardBLL(bool v)
        {
            throw new NotImplementedException();
        }
    }
}