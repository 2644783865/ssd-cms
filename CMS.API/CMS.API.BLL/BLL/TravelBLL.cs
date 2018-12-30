using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class TravelBLL : ITravelBLL
    {
        private ITravelRepository _repository = new TravelRepository();

        public IEnumerable<TravelInfoDTO> GetTravelInfo()
        {
            try
            {
                return _repository.GetTravelInfo();
            }
            catch
            {
                return null;
            }
        }

        public TravelInfoDTO GetTravelById(int id)
        {
            try
            {
                var travel = _repository.GetTravelInfoById(id);
                if (travel == null) return null;
                return travel;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<TravelInfoDTO> GetTravelInfoByConferenceId(int id)
        {
            try
            {
                return _repository.GetTravelInfoByConferenceId(id);
            }
            catch
            {
                return null;
            }
        }

        public bool AddTravel(TravelInfoDTO travel)
        {
            try
            {
                _repository.AddTravel(travel);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditTravel(TravelInfoDTO travel)
        {
            try
            {
                _repository.EditTravel(travel);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteTravel(int travelId)
        {
            try
            {
                _repository.DeleteTravel(travelId);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
