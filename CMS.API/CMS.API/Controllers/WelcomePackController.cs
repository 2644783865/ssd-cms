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

        // GET: api/WelcomePack/WelcomePackInfo
        [HttpGet]
        [Route("api/welcomepack/welcomepackinfo")]
        public IHttpActionResult GetWelcomePackInfo()
        {
            return Ok(_bll.GetWelcomePackInfo());
        }

        // GET: api/WelcomePack/WelcomePackById?wpackid=
        [HttpGet]
        [Route("api/welcomepack/welcomepackbyid")]
        public IHttpActionResult GetWelcomePackById(int wpackid)
        {
            var wpack = _bll.GetWelcomePackById(wpackid);
            if (wpack == null) return BadRequest();
            return Ok(wpack);
        }

        // POST: api/WelcomePack/AddWelcomePack
        [HttpPost]
        [Route("api/welcomepack/addwelcomepack")]
        public IHttpActionResult AddWelcomePack([FromBody] WelcomePackDTO wpack)
        {if (_bll.AddWelcomePack(wpack)) return Ok();
            return InternalServerError();
        }

        // PUT: api/WelcomePack/EditWelcomePack
        [HttpPut]
        [Route("api/welcomepack/editwelcomepack")]
        public IHttpActionResult EditWelcomePack([FromBody] WelcomePackDTO wpack)
        {if (_bll.EditWelcomePack(wpack)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/WelcomePack/DeleteWelcomePack?wpackid=
        [HttpDelete]
        [Route("api/welcomepack/deletewelcomepack")]
        public IHttpActionResult DeleteWelcomePack(int wpackid)
        {
            if (_bll.DeleteWelcomePack(wpackid)) return Ok();
            return InternalServerError();
        }

        // GET: api/WelcomePackGift/WelcomePackGiftInfo
        [HttpGet]
        [Route("api/welcomepackgift/welcomepackgiftinfo")]
        public IHttpActionResult GetWelcomePackGiftInfo()
        {
            return Ok(_bll.GetWelcomePackGiftInfo());
        }

        // GET: api/WelcomePackGift/WelcomePackGiftkById?wpackid=
        [HttpGet]
        [Route("api/welcomepackgift/welcomepackgiftbyid")]
        public IHttpActionResult GetWelcomePackGiftById(int wpackgiftid)
        {
            var gift = _bll.GetWelcomePackGiftById(wpackgiftid);
            if (gift == null) return BadRequest();
            return Ok(gift);
        }

        // POST: api/WelcomePackGift/AddWelcomePackGift
        [HttpPost]
        [Route("api/welcomepackgift/addwelcomepackgift")]
        public IHttpActionResult AddWelcomePackGift([FromBody] WelcomePackGiftDTO gift)
        {
            if (_bll.AddWelcomePackGift(gift)) return Ok();
            return InternalServerError();
        }

        // PUT: api/WelcomePackGift/EditWelcomePackGift
        [HttpPut]
        [Route("api/welcomepackgift/editwelcomepackgift")]
        public IHttpActionResult EditWelcomePackGift([FromBody] WelcomePackGiftDTO gift)
        {
            if (_bll.EditWelcomePackGift(gift)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/WelcomePackGift/DeleteWelcomePackGift?giftid=
        [HttpDelete]
        [Route("api/welcomepackgift/deletewelcomepackgift")]
        public IHttpActionResult DeleteWelcomePackGift(int giftid)
        {
            if (_bll.DeleteWelcomePackGift(giftid)) return Ok();
            return InternalServerError();
        }

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