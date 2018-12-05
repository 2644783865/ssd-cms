using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IEmergencyInfoCore : IDisposable
    {
        Task<List<EmergencyInfoDTO>> GetEmergencyInfoInfoAsync();
        Task<EmergencyInfoDTO> GetEmergencyInfoByIdAsync(int emergencyInfoId);
        Task<bool> AddEmergencyInfoAsync(EmergencyInfoDTO emergencyInfo);
        Task<bool> EditEmergencyInfoAsync(EmergencyInfoDTO emergencyInfo);
        Task<bool> DeleteEmergencyInfoAsync(int emergencyInfoId);
    }
}
