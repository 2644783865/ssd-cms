using CMS.API.BLL.Interfaces.Conference;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL.Conference
{
    public class ConferenceBLL : IConferenceBLL
    {
        private IConferenceRepository _repository = new ConferenceRepository();

        public IEnumerable<ConferenceDTO> GetConferences()
        {
            return _repository.GetConferences();
        }

        public bool AddConference(ConferenceDTO conference)
        {
            try
            {
                _repository.AddConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
