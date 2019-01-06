using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models;
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

        // GET: api/Conference/ConferenceById?conferenceId=
        [HttpGet]
        [Route("api/conference/conferencebyid")]
        public IHttpActionResult GetConferences(int conferenceId)
        {
            var conference = _bll.GetConferenceById(conferenceId);
            if (conference == null) return BadRequest();
            return Ok(conference);
        }

        // POST: api/Conference/AddConference
        [HttpPost]
        [Route("api/conference/addconference")]
        public IHttpActionResult AddConference([FromBody] ConferenceDTO conference)
        {
            if (string.IsNullOrEmpty(conference.Title) || string.IsNullOrEmpty(conference.Place)
                || conference.BeginDate== default(DateTime) || conference.EndDate == default(DateTime)) return BadRequest();
            if (_bll.AddConference(conference)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Conference/EditConference
        [HttpPut]
        [Route("api/conference/editconference")]
        public IHttpActionResult EditConference([FromBody] ConferenceDTO conference)
        {
            if (string.IsNullOrEmpty(conference.Title) || string.IsNullOrEmpty(conference.Place)
                || conference.BeginDate == default(DateTime) || conference.EndDate == default(DateTime)) return BadRequest();
            if (_bll.EditConference(conference)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Conference/DeleteConference?conferenceId=
        [HttpDelete]
        [Route("api/conference/deleteconference")]
        public IHttpActionResult DeleteConference(int conferenceId)
        {
            if (_bll.DeleteConference(conferenceId)) return Ok();
            return InternalServerError();
        }

        // GET: api/Conference/Program
        [HttpGet]
        [Route("api/conference/program")]
        public IHttpActionResult GetConferenceProgram(int conferenceId)
        {
            try
            {
                var model = _bll.GetConferenceProgram(conferenceId);
                PdfController controller = PdfHelper.Setup("GetProgram");
                return Ok(new ByteArray() { Content = controller.GetProgram(model) });
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Conference/Schedule
        [HttpGet]
        [Route("api/conference/schedule")]
        public IHttpActionResult GetConferenceSchedule(int accountId, int conferenceId)
        {
            try
            {
                var model = _bll.GetConferenceSchedule(accountId, conferenceId);
                PdfController controller = PdfHelper.Setup("GetSchedule");
                return Ok(new ByteArray() { Content = controller.GetSchedule(model) });
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Conference/ScheduleICal
        [HttpGet]
        [Route("api/conference/scheduleical")]
        public IHttpActionResult GetConferenceScheduleICal(int accountId, int conferenceId)
        {
            try
            {
                var schedule = _bll.GetConferenceScheduleICal(accountId, conferenceId);
                return Ok(new ByteArray() { Content = schedule });
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
