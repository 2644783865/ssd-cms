using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IAccommodationInfoRepository : IDisposable
    {
        IEnumerable<AccommodationInfoDTO> GetAccommodationInfoInfo();
        AccommodationInfoDTO GetAccommodationInfoById(int id);
        void AddAccommodationInfo(AccommodationInfoDTO accommodationDTO);
        void EditAccommodationInfo(AccommodationInfoDTO accommodationDTO);
        void DeleteAccommodationInfo(int accommodationId);
    }
}
