using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IConferenceCore : IDisposable
    {
        Task<List<ConferenceDTO>> GetConferencesAsync();
        Task<ConferenceDTO> GetConferenceByIdAsync(int conferenceId);
        Task<bool> AddConferenceAsync(ConferenceDTO conference);
        Task<bool> EditConferenceAsync(ConferenceDTO conference);
        Task<bool> DeleteConferenceAsync(int conferenceId);
        Task<byte[]> GetConferenceProgramAsync(int conferenceId);
        Task<byte[]> GetConferenceScheduleAsync(int accountId, int conferenceId);
        Task<byte[]> GetConferenceScheduleICalAsync(int accountId, int conferenceId);
    }
}
