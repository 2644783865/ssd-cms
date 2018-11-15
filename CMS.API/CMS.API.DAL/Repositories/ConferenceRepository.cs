using CMS.API.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<Conference> GetConferences()
        {
            var conferences = _db.Conferences.ToList();
            foreach (var conference in conferences)
            {
                yield return new Conference()
                {
                    ConferenceId = conference.ConferenceId,
                    BeginDate = conference.BeginDate,
                    Description = conference.Description,
                    EndDate = conference.EndDate,
                    Place = conference.Place,
                    Title = conference.Title
                };
            }
        }

        public void AddConference(Conference conference)
        {
            _db.Conferences.Add(conference);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
