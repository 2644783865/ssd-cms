using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface ITravelBLL
    {
        IEnumerable<TravelInfoDTO> GetTravelInfo();
        TravelInfoDTO GetTravelById(int id);
        bool AddTravel(TravelInfoDTO travel);
        bool EditTravel(TravelInfoDTO travel);
        bool DeleteTravel(int travelId);
    }
}

