using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces.Conference
{
    public interface IConferenceBLL
    {
        IEnumerable<ConferenceDTO> GetConferences();
        bool AddConference(ConferenceDTO conference);
    }
}
