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
        public IHttpActionResult GetLastMessageByPairId(int PairId)
        {
            var lastmessage = _bll.GetLastMessageByPairId(PairId);
            if (lastmessage == null) return BadRequest();
            return Ok(lastmessage);
        }

        // GET: api/LastMessage/GetLastMessageByFirstId?FirstId=
        [HttpGet]
        [Route("api/lastmessage/getlastmessagebysenderid")]
        public IHttpActionResult getlastmessagebyfirstid(int FirstId)
        {
            var lastmessage = _bll.GetLastMessageByFirstId(FirstId);
            if (lastmessage == null) return BadRequest();
            return Ok(lastmessage);
        }

        // GET: api/LastMessage/GetLastMessageBySecondId?SecondId=
        [HttpGet]
        [Route("api/lastmessage/getlastmessagebysecondid")]
        public IHttpActionResult GetLastMessageBySecondId(int SecondId)
        {
            var lastmessage = _bll.GetLastMessageBySecondId(SecondId);
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
        public IHttpActionResult DeleteLastMessage(int PairId)
        {
            if (_bll.DeleteLastMessage(PairId)) return Ok();
            return InternalServerError();
        }
    }
}
