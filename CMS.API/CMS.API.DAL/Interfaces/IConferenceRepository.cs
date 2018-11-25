using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IConferenceRepository : IDisposable
    {
        IEnumerable<ConferenceDTO> GetConferences();
        ConferenceDTO GetConferenceById(int id);
        void AddConference(ConferenceDTO conferenceDTO);
        void EditConference(ConferenceDTO conferenceDTO);
        void DeleteConference(int conferenceId);
    }
}
