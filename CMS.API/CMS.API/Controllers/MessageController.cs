using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class MessageController : ApiController
    {
        private IMessageBLL _bll = new MessageBLL();
        
        // GET: api/Message/Message
        [HttpGet]
        [Route("api/message/message")]
        public IHttpActionResult GetMessages()
        {
            return Ok(_bll.GetMessages());
        }

        // GET: api/Message/GetMessageById?messageId=
        [HttpGet]
        [Route("api/message/getmessagebyid")]
        public IHttpActionResult GetMessageById(int messageId)
        {
            var message = _bll.GetMessageById(messageId);
            if (message == null) return BadRequest();
            return Ok(message);
        }

        // GET: api/Message/GetMessageBySenderId?senderId=
        [HttpGet]
        [Route("api/message/getmessagebysenderid")]
        public IHttpActionResult GetMessagesBySenderId(int senderId)
        {
            var message = _bll.GetMessagesBySenderId(senderId);
            if (message == null) return BadRequest();
            return Ok(message);
        }
        // GET: api/Message/GetMessageByReceiverId?receiverId=
        [HttpGet]
        [Route("api/message/getmessagebyreceiverid")]
        public IHttpActionResult GetMessagesByReceiverId(int receiverId)
        {
            var message = _bll.GetMessagesByReceiverId(receiverId);
            if (message == null) return BadRequest();
            return Ok(message);
        }


        
        // GET: api/Message/GetMessagesByAccountId?accountId=
        [HttpGet]
        [Route("api/message/getmessagesbyaccountid")]
        public IHttpActionResult GetMessagesByAccountId(int accountId)
        {
            var messages = _bll.GetMessagesByAccountId(accountId);
            if (messages == null) return BadRequest();
            return Ok(messages);
        }

        // GET: api/Message/GetMessagesByAccountId?accountId=
        [HttpGet]
        [Route("api/message/getmessagesbytargetid")]
        public IHttpActionResult GetMessagesByTargetAccountId(int requesterId, int targetId)
        {
            var messages = _bll.GetMessagesByTargetId(requesterId, targetId);
            if (messages == null) return BadRequest();
            return Ok(messages);
        }

        // GET: api/Message/GetLastMessagesByAccountId?accountId=
        [HttpGet]
        [Route("api/message/getlastmessagesbyaccountid")]
        public IHttpActionResult GetLastMessagesByAccountId(int accountId)
        {
            var messages = _bll.GetLastMessagesByAccountId(accountId);
            if (messages == null) return BadRequest();
            return Ok(messages);
        }

        // POST: api/Message/AddMessage
        [HttpPost]
        [Route("api/message/addmessage")]
        public IHttpActionResult AddMessage([FromBody] MessageDTO message)
        {
            if (string.IsNullOrEmpty(message.Content)) return BadRequest();
            if (_bll.AddMessage(message)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Message/EditMessage
        [HttpPut]
        [Route("api/message/editmessage")]
        public IHttpActionResult EditMessage([FromBody] MessageDTO message)
        {
            if (string.IsNullOrEmpty(message.Content)) return BadRequest();
            if (_bll.EditMessage(message)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Message/DeleteMessage?messageId=
        [HttpDelete]
        [Route("api/message/deletemessage")]
        public IHttpActionResult DeleteMessage(int messageId)
        {
            if (_bll.DeleteMessage(messageId)) return Ok();
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/message/markreceived")]
        public IHttpActionResult markReceived(int FirstId, int SecondId)
        {
            if (_bll.markReceived(FirstId, SecondId)) return Ok();
            return InternalServerError();

        }
    }
}
