using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class SessionController : ApiController
    {
        private ISessionBLL _bll = new SessionBLL();

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
