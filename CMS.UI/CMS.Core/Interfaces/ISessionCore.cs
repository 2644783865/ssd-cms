﻿using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface ISessionCore : IDisposable
    {
        
        Task<List<SessionDTO>> GetSessionsAsync(int conferenceID);
        Task<SessionDTO> GetSessionByIdAsync(int sessionId);
        Task<bool> AddSessionAsync(SessionDTO session);
        Task<bool> EditSessionAsync(SessionDTO session);
        Task<bool> DeleteSessionAsync(int sessionId);
        Task<Response> CheckOverlappingSessiondAsync(int conferenceId, DateTime begin, DateTime end);

        Task<List<SpecialSessionDTO>> GetSpecialSessionsAsync(int conferenceID);
        Task<SpecialSessionDTO> GetSpecialSessionByIdAsync(int specialSessionId);
        Task<bool> AddSpecialSessionAsync(SpecialSessionDTO specialSessio);
        Task<bool> EditSpecialSessionAsync(SpecialSessionDTO specialSessio);
        Task<bool> DeleteSpecialSessionAsync(int specialSessionId);
    }
}
