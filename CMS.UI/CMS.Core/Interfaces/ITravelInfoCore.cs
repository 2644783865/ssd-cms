using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface ITravelInfoCore : IDisposable
    {
        Task<List<TravelInfoDTO>> GetTravelInfoAsync();
        Task<TravelInfoDTO> GetTravelByIdAsync(int travelId);
        Task<List<TravelInfoDTO>> GetTravelInfoByConferenceIdAsync(int conferenceid);
        Task<bool> AddTravelAsync(TravelInfoDTO travel);
        Task<bool> EditTravelAsync(TravelInfoDTO travel);
        Task<bool> DeleteTravelAsync(int travelId);
    }
}
