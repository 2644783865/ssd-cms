using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class AccommodationInfoBLL : IAccommodationInfoBLL
    {
        private IAccommodationInfoRepository _repository = new AccommodationInfoRepository();

        public IEnumerable<AccommodationInfoDTO> GetAccommodationInfoInfo()
        {
            try
            {
                return _repository.GetAccommodationInfoInfo();
            }
            catch
            {
                return null;
            }
        }

        public AccommodationInfoDTO GetAccommodationInfoById(int id)
        {
            try
            {
                var acommodationinfo = _repository.GetAccommodationInfoById(id);
                if (acommodationinfo == null) return null;
                return acommodationinfo;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<AccommodationInfoDTO> GetAccommodationInfoByConferenceId(int id)
        {
            try
            {
                return _repository.GetAccommodationInfoByConferenceId(id);
            }
            catch
            {
                return null;
            }
        }

        public bool AddAccommodationInfo(AccommodationInfoDTO acommodationinfo)
        {
            try
            {
                _repository.AddAccommodationInfo(acommodationinfo);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditAccommodationInfo(AccommodationInfoDTO acommodationinfo)
        {
            try
            {
                _repository.EditAccommodationInfo(acommodationinfo);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAccommodationInfo(int acommodationinfoId)
        {
            try
            {
                _repository.DeleteAccommodationInfo(acommodationinfoId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
