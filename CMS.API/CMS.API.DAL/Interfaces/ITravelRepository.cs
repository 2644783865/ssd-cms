using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface ITravelRepository : IDisposable
    {
        IEnumerable<TravelInfoDTO> GetTravelInfo();
        TravelInfoDTO GetTravelInfoById(int id);
        IEnumerable<TravelInfoDTO> GetTravelInfoByConferenceId(int id);
        void AddTravel(TravelInfoDTO travelDTO);
        void EditTravel(TravelInfoDTO travelDTO);
        void DeleteTravel(int travelId);
    }
}
