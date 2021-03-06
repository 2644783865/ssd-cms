﻿using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models;
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

        // POST: api/Event/CheckOverlappingEvent?conferenceId=
        [HttpPost]
        [Route("api/session/checkoverlappingevent")]
        public IHttpActionResult CheckOverlappingEvent(int conferenceId, [FromBody] DateModel dateModel)
        {
            var events = _bll.CheckOverlappingEvent(conferenceId, dateModel.beginDate, dateModel.endDate);
            if (events == null) return BadRequest();
            return Ok(events);
        }
    }
}
