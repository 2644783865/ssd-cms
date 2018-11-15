using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IConferenceRepository : IDisposable
    {
        IEnumerable<Conference> GetConferences();
        void AddConference(Conference conference);
    }
}
