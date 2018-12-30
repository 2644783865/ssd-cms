using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IAccommodationInfoBLL
    {
        IEnumerable<AccommodationInfoDTO> GetAccommodationInfoInfo();
        AccommodationInfoDTO GetAccommodationInfoById(int id);
        IEnumerable<AccommodationInfoDTO> GetAccommodationInfoByConferenceId(int id);
        bool AddAccommodationInfo(AccommodationInfoDTO accommodationInfo);
        bool EditAccommodationInfo(AccommodationInfoDTO accommodationInfo);
        bool DeleteAccommodationInfo(int accommodationInfoId);
    }
}
