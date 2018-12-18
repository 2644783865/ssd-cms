using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class EventController : ApiController
    {
        private IEventBLL _bll = new EventBLL();

        // GET: api/Event/Events?ConferenceId=
        [HttpGet]
        [Route("api/event/events")]
        public IHttpActionResult GetEvents(int conferenceId)
        {
            return Ok(_bll.GetEvents(conferenceId));
        }
        // GET: api/Event/EventById?EventId=
        [HttpGet]
        [Route("api/event/eventbyid")]

        public IHttpActionResult GetEventById(int eventId)
        {
            var Event = _bll.GetEventById(eventId);
            if (Event == null) return BadRequest();
            return Ok(Event);
        }

        // POST: api/Event/AddEvent
        [HttpPost]
        [Route("api/event/addevent")]
        public IHttpActionResult AddEvent([FromBody] EventDTO Event)
        {
            if (_bll.AddEvent(Event)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Event/EditEvent
        [HttpPut]
        [Route("api/event/editevent")]
        public IHttpActionResult EditEvent([FromBody] EventDTO Event)
        {
            if (_bll.EditEvent(Event)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Event/DeleteEvent?EventId=
        [HttpDelete]
        [Route("api/event/deleteevent")]
        public IHttpActionResult DeleteEvent(int eventId)
        {
            if (_bll.DeleteEvent(eventId)) return Ok();
            return InternalServerError();
        }

        // GET: api/Event/CheckOverlappingEvent?conferenceId=&begin=&end=
        [HttpGet]
        [Route("api/session/checkoverlappingevent")]
        public IHttpActionResult CheckOverlappingEvent(int conferenceId, DateTime begin, DateTime end)
        {
            var events = _bll.CheckOverlappingEvent(conferenceId, begin, end);
            if (events == null) return BadRequest();
            return Ok(events);
        }
    }
}
