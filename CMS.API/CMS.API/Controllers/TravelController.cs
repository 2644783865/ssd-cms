using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class TravelController : ApiController
    {
        private ITravelBLL _bll = new TravelBLL();

        // GET: api/TravelInfo/TravelInfo
        [HttpGet]
        [Route("api/travelinfo/travelinfo")]
        public IHttpActionResult GetTravelInfo()
        {
            return Ok(_bll.GetTravelInfo());
        }

        // GET: api/TravelInfo/TravelById?travelinfoid=
        [HttpGet]
        [Route("api/travelinfo/travelbyid")]
        public IHttpActionResult GetTravelById(int travelid)
        {
            var travel = _bll.GetTravelById(travelid);
            if (travel == null) return BadRequest();
            return Ok(travel);
        }

        // POST: api/TravelInfo/AddTravel
        [HttpPost]
        [Route("api/travelinfo/addtravel")]
        public IHttpActionResult AddTravel([FromBody] TravelInfoDTO travel)
        {
            if (_bll.AddTravel(travel)) return Ok();
            return InternalServerError();
        }

        // PUT: api/TravelInfo/EditTravel
        [HttpPut]
        [Route("api/travelinfo/edittravel")]
        public IHttpActionResult EditTravel([FromBody] TravelInfoDTO travel)
        {
            if (_bll.EditTravel(travel)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/TravelInfo/DeleteTravel?travelId=
        [HttpDelete]
        [Route("api/travelinfo/deletetravel")]
        public IHttpActionResult DeleteTravel(int travelid)
        {
            if (_bll.DeleteTravel(travelid)) return Ok();
            return InternalServerError();
        }
    }
}