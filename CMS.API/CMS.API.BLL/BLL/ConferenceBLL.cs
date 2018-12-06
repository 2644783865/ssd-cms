using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Program;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class ConferenceBLL : IConferenceBLL
    {
        private IConferenceRepository _repository = new ConferenceRepository();

        public IEnumerable<ConferenceDTO> GetConferences()
        {
            try
            {
                return _repository.GetConferences();
            }
            catch
            {
                return null;
            }
        }

        public ConferenceDTO GetConferenceById(int id)
        {
            try
            {
                var conference = _repository.GetConferenceById(id);
                if (conference == null) return null;
                return conference;
            }
            catch
            {
                return null;
            }
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

        public bool EditConference(ConferenceDTO conference)
        {
            try
            {
                _repository.EditConference(conference);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteConference(int conferenceId)
        {
            try
            {
                _repository.DeleteConference(conferenceId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public ConferenceProgramModel GetConferenceProgram(int conferenceId)
        {
            // not implemented
            var conference = _repository.GetConferenceById(conferenceId);
            return new ConferenceProgramModel()
            {
                Conference = conference
            };
        }
    }
}
