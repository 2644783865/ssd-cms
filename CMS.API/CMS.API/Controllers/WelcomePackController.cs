using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class WelcomePackController : ApiController
    {
        private IWelcomePackBLL _bll = new WelcomePackBLL();

        // GET: api/WelcomePackReceiver/WelcomePackReceiverInfo
        [HttpGet]
        [Route("api/welcomepackreceiver/welcomepackreceiverinfo")]
        public IHttpActionResult GetWelcomePackReceiverInfo()
        {
            return Ok(_bll.GetWelcomePackReceiverInfo ());
        }

        // GET: api/WelcomePackReceiver/WelcomePackReceiverById?wpackid=
        [HttpGet]
        [Route("api/welcomepackreceiver/welcomepackreceiverbyid")]
        public IHttpActionResult GetWelcomePackReceiverById(int receiverid)
        {
            var receiver = _bll.GetWelcomePackReceiverById(receiverid);
            if (receiver == null) return BadRequest();
            return Ok(receiver);
        }

        // GET: api/WelcomePackReceiver/GuestsByConferenceId?conferenceid=
        [HttpGet]
        [Route("api/welcomepackreceiver/guestsbyconferenceid")]
        public IHttpActionResult GetGuestsByConferenceId(int conferenceid)
        {
            var receiver = _bll.GetGuestsByConferenceId(conferenceid);
            if (receiver == null) return BadRequest();
            return Ok(receiver);
        }

        // POST: api/WelcomePackReceiver/AddWelcomePackReceiver
        [HttpPost]
        [Route("api/welcomepackreceiver/addwelcomepackreceiver")]
        public IHttpActionResult AddWelcomePackReceiver([FromBody] WelcomePackReceiverDTO receiver)
        {
            if (string.IsNullOrEmpty(receiver.Type)) return BadRequest();
            if (_bll.AddWelcomePackReceiver(receiver)) return Ok();
            return InternalServerError();
        }

        // PUT: api/WelcomePackReceiver/EditWelcomePackReceiver
        [HttpPut]
        [Route("api/welcomepackreceiver/editwelcomepackreceiver")]
        public IHttpActionResult EditWelcomePackReceiver([FromBody] WelcomePackReceiverDTO receiver)
        {
            if (string.IsNullOrEmpty(receiver.Type)) return BadRequest();
            if (_bll.EditWelcomePackReceiver(receiver)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/WelcomePackReceiver/DeleteWelcomePackReceiver?receiverid=
        [HttpDelete]
        [Route("api/welcomepackreceiver/deletewelcomepackreceiver")]
        public IHttpActionResult DeleteWelcomePackReceiver(int receiverid)
        {
            if (_bll.DeleteWelcomePackReceiver(receiverid)) return Ok();
            return InternalServerError();
        }
    }
}