using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class MessageController : ApiController
    {
        private IMessageBLL _bll = new MessageBLL();

        // POST: api/Message/AddMessage
        [HttpPost]
        [Route("api/message/addmessage")]
        public IHttpActionResult AddMessage([FromBody] MessageDTO message)
        {
            if (string.IsNullOrEmpty(message.Content) || message.Date == default(DateTime)) return BadRequest();
            if (_bll.AddMessage(message)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Message/EditMessage
        [HttpPut]
        [Route("api/message/editmessage")]
        public IHttpActionResult EditMessage([FromBody] MessageDTO message)
        {
            if (string.IsNullOrEmpty(message.Content) || message.Date == default(DateTime)) return BadRequest();
            if (_bll.EditMessage(message)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Message/DeleteMessage?groupId=&sequenceNumber=
        [HttpDelete]
        [Route("api/message/deletemessage")]
        public IHttpActionResult DeleteMessage(int groupId, int sequenceNumber)
        {
            if (_bll.DeleteMessage(groupId, sequenceNumber)) return Ok();
            return InternalServerError();
        }
    }
}
