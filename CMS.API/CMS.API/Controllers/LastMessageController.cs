using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class LastMessageController : ApiController
    {
        private ILastMessageBLL _bll = new LastMessageBLL();

        // GET: api/LastMessage/GetLastMessageByPairId?PairId=
        [HttpGet]
        [Route("api/lastmessage/getlastmessagebypairid")]
        public IHttpActionResult GetLastMessageByPairId(int pairId)
        {
            var lastmessage = _bll.GetLastMessageByPairId(pairId);
            if (lastmessage == null) return BadRequest();
            return Ok(lastmessage);
        }

        // GET: api/LastMessage/GetLastMessageByFirstId?FirstId=
        [HttpGet]
        [Route("api/lastmessage/getlastmessagebysenderid")]
        public IHttpActionResult getlastmessagebyfirstid(int firstId)
        {
            var lastmessage = _bll.GetLastMessageByFirstId(firstId);
            if (lastmessage == null) return BadRequest();
            return Ok(lastmessage);
        }

        // GET: api/LastMessage/GetLastMessageBySecondId?SecondId=
        [HttpGet]
        [Route("api/lastmessage/getlastmessagebysecondid")]
        public IHttpActionResult GetLastMessageBySecondId(int secondId)
        {
            var lastmessage = _bll.GetLastMessageBySecondId(secondId);
            if (lastmessage == null) return BadRequest();
            return Ok(lastmessage);
        }

        // POST: api/LastMessage/AddLastMessage
        [HttpPost]
        [Route("api/lastmessage/addlastmessage")]
        public IHttpActionResult AddLastMessage([FromBody] LastMessageDTO lastmessage)
        {
            if (string.IsNullOrEmpty(lastmessage.LastMessage)) return BadRequest();
            if (_bll.AddLastMessage(lastmessage)) return Ok();
            return InternalServerError();
        }

        // PUT: api/LastMessage/EditLastMessage
        [HttpPut]
        [Route("api/lastmessage/editlastmessage")]
        public IHttpActionResult EditLastMessage([FromBody] LastMessageDTO lastmessage)
        {
            if (string.IsNullOrEmpty(lastmessage.LastMessage)) return BadRequest();
            if (_bll.EditLastMessage(lastmessage)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/LastMessage/DeleteLastMessage?PairId=
        [HttpDelete]
        [Route("api/lastmessage/deletelastmessage")]
        public IHttpActionResult DeleteLastMessage(int pairId)
        {
            if (_bll.DeleteLastMessage(pairId)) return Ok();
            return InternalServerError();
        }
    }
}
