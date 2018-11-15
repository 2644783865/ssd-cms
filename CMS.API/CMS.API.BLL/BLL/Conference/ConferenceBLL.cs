using CMS.API.BLL.Interfaces.Conference;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;

namespace CMS.API.BLL.BLL.Conference
{
    public class ConferenceBLL : IConferenceBLL
    {
        private IConferenceRepository _repository = new ConferenceRepository();

        public object GetConferences()
        {
            return _repository.GetConferences();
        }

        public bool AddConference(DAL.Conference conference)
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
