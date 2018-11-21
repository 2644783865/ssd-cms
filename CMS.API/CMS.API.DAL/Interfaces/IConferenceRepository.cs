using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IConferenceRepository : IDisposable
    {
        IEnumerable<ConferenceDTO> GetConferences();
        void AddConference(ConferenceDTO conference);
    }
}
