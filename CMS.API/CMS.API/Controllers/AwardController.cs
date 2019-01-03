using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class AwardController : ApiController
    {
        private IAwardBLL _bll = new AwardBLL();

        // GET: api/Award/Awards
        [HttpGet]
        [Route("api/award/awards")]
        public IHttpActionResult GetAwards()
        {
            return Ok(_bll.GetAwards());
        }
        // GET: api/Award/AwardById?awardId=
        [HttpGet]
        [Route("api/award/awardbyid")]

        public IHttpActionResult GetAwardById(int awardId)
        {
            var award = _bll.GetAwardById(awardId);
            return Ok(award);
        }

        // POST: api/Award/AddAward
        [HttpPost]
        [Route("api/award/addaward")]
        public IHttpActionResult AddAward([FromBody] AwardDTO award)
        {
            if (_bll.AddAward(award)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Award/EditAward
        [HttpPut]
        [Route("api/award/editaward")]
        public IHttpActionResult EditAward([FromBody] AwardDTO award)
        {
            if (_bll.EditAward(award)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Award/DeleteAward?awardId=
        [HttpDelete]
        [Route("api/award/deleteaward")]
        public IHttpActionResult DeleteAward(int awardId)
        {
            if (_bll.DeleteAward(awardId)) return Ok();
            return InternalServerError();
        }
    }
}
