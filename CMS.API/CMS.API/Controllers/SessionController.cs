using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class SessionController : ApiController
    {
        private ISessionBLL _bll = new SessionBLL();

        // GET: api/Session/GetSessionById?sessionId=
        [HttpGet]
        [Route("api/session/getsessionbyid")]
        public IHttpActionResult GetSessionById(int sessionId)
        {
            var session = _bll.GetSessionByID(sessionId);
            if (session == null) return BadRequest();
            return Ok(session);
        }

        // GET: api/Session/GetSessions?conferenceID=
        [HttpGet]
        [Route("api/session/getsessions")]
        public IHttpActionResult GetSessions(int conferenceID)
        {
            var sessions = _bll.GetSessions(conferenceID);
            if (sessions == null) return BadRequest();
            return Ok(sessions);
        }

        // POST: api/Session/AddSession
        [HttpPost]
        [Route("api/session/addsession")]
        public IHttpActionResult AddSession([FromBody] SessionDTO session)
        {
            if (string.IsNullOrEmpty(session.Title)) return BadRequest();
            if (_bll.AddSession(session)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Session/EditSession
        [HttpPut]
        [Route("api/session/editsession")]
        public IHttpActionResult EditSession([FromBody] SessionDTO session)
        {
            if (string.IsNullOrEmpty(session.Title)) return BadRequest();
            if (_bll.EditSession(session)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Session/DeleteSession?sessionId=
        [HttpDelete]
        [Route("api/session/deletesession")]
        public IHttpActionResult DeleteSession(int sessionId)
        {
            if (_bll.DeleteSession(sessionId)) return Ok();
            return InternalServerError();
        }

        // GET: api/Session/CheckOverlappingSession?conferenceId=&eventId=
        [HttpPost]
        [Route("api/session/checkoverlappingsession")]
        public IHttpActionResult CheckOverlappingSession(int conferenceId, int eventId, [FromBody] DateModel dateModel)
        {
            var session = _bll.CheckOverlappingSession(conferenceId, dateModel.beginDate, dateModel.endDate, eventId);
            if (session == null) return BadRequest();
            return Ok(session);
        }

        // POST: api/Session/CheckOverlappingSessionForChairman?chairId=&sessionId=&specialSessionId=
        [HttpPost]
        [Route("api/session/checkoverlappingsessionforchairman")]
        public IHttpActionResult CheckOverlappingSessionForChairman(int chairId, int sessionId, int specialSessionId, [FromBody] DateModel dateModel)
        {
            var session = _bll.CheckOverlappingSessionForChairman(chairId, dateModel.beginDate, dateModel.endDate, sessionId, specialSessionId);
            if (session == null) return BadRequest();
            return Ok(session);
        }



        // GET: api/Session/GetSpecialSessionById?specialSessionId=
        [HttpGet]
        [Route("api/session/getspecialsessionbyid")]
        public IHttpActionResult GetSpecialSessionById(int specialSessionId)
        {
            var specialsession = _bll.GetSpecialSessionByID(specialSessionId);
            if (specialsession == null) return BadRequest();
            return Ok(specialsession);
        }

        // GET: api/Session/GetSpecialSessions?conferenceID=
        [HttpGet]
        [Route("api/session/getspecialsessions")]
        public IHttpActionResult GetSpecialSessions(int conferenceID)
        {
            var specialsession = _bll.GetSpecialSessions(conferenceID);
            if (specialsession == null) return BadRequest();
            return Ok(specialsession);
        }

        // POST: api/Session/AddSpecialSession
        [HttpPost]
        [Route("api/session/addsespecialsession")]
        public IHttpActionResult AddSpecialSession([FromBody] SpecialSessionDTO specialSession)
        {
            if (string.IsNullOrEmpty(specialSession.Title)) return BadRequest();
            if (_bll.AddSpecialSession(specialSession)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Session/EditSpecialSession
        [HttpPut]
        [Route("api/session/editspecialsession")]
        public IHttpActionResult EditSpecialSession([FromBody] SpecialSessionDTO specialSession)
        {
            if (string.IsNullOrEmpty(specialSession.Title)) return BadRequest();
            if (_bll.EditSpecialSession(specialSession)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Session/DeleteSpecialSession?specialSessionId=
        [HttpDelete]
        [Route("api/session/deletespecialsession")]
        public IHttpActionResult DeleteSpecialSession(int specialSessionId)
        {
            if (_bll.DeleteSpecialSession(specialSessionId)) return Ok();
            return InternalServerError();
        }
    }
}
