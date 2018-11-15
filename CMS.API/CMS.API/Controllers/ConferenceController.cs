using CMS.API.BLL.BLL.Conference;
using CMS.API.BLL.Interfaces.Conference;
using CMS.API.Helpers;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class ConferenceController : ApiController
    {
        private IConferenceBLL _bll = new ConferenceBLL();

        // GET: api/Conference/Conferences
        [HttpGet]
        [Route("api/conference/conferences")]
        public IHttpActionResult GetConferences()
        {
            return Ok(_bll.GetConferences());
        }

        // POST: api/Conference/AddConference
        [HttpPost]
        [Route("api/conference/addconference")]
        public IHttpActionResult AddConference([FromBody] DAL.Conference conference)
        {
            if (string.IsNullOrEmpty(conference.Title) || string.IsNullOrEmpty(conference.Place)
                || conference.BeginDate== default(DateTime) || conference.EndDate == default(DateTime)) return BadRequest();
            if (_bll.AddConference(conference)) return Ok();
            return InternalServerError();
        }
    }
}
