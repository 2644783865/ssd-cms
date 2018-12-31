using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IAccommodationInfoCore : IDisposable
    {
        Task<List<AccommodationInfoDTO>> GetAccommodationInfoInfoAsync();
        Task<AccommodationInfoDTO> GetAccommodationInfoByIdAsync(int accommodationInfoId);
        Task<bool> AddAccommodationInfoAsync(AccommodationInfoDTO accommodationInfo);
        Task<bool> EditAccommodationInfoAsync(AccommodationInfoDTO accommodationInfo);
        Task<bool> DeleteAccommodationInfoAsync(int accommodationInfoId);

        Task<List<AccommodationInfoDTO>> GetAccommodationInfoByConferenceId(int id);
    }
}
