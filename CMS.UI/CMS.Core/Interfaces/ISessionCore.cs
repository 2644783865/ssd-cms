﻿using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface ISessionCore : IDisposable
    {
        /*
        Task<List<SessionDTO>> GetSessionsAsync();
        Task<SessionDTO> GetSessionByIdAsync(int sessionId);*/
        Task<bool> AddSessionAsync(SessionDTO session);
        Task<bool> EditSessionAsync(SessionDTO session);
        Task<bool> DeleteSessionAsync(int sessionId);

        /*
        Task<List<SpecialSessionDTO>> GetSpecialSessionsAsync();
        Task<SpecialSessionDTO> GetSpecialSessionByIdAsync(int specialSessionId);*/
        Task<bool> AddSpecialSessionAsync(SpecialSessionDTO specialSessio);
        Task<bool> EditSpecialSessionAsync(SpecialSessionDTO specialSessio);
        Task<bool> DeleteSpecialSessionAsync(int specialSessionId);
    }
}
