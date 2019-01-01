using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class AccommodationInfoController : ApiController
    {
        private IAccommodationInfoBLL _bll = new AccommodationInfoBLL();

        // GET: api/AccommodationInfo/AccommodationInfoInfo
        [HttpGet]
        [Route("api/accommodationinfo/accommodationinfoinfo")]
        public IHttpActionResult GetAccommodationInfoInfo()
        {
            return Ok(_bll.GetAccommodationInfoInfo());
        }

        // GET: api/AccommodationInfo/AccommodationInfoById?accommodationinfoId=
        [HttpGet]
        [Route("api/accommodationinfo/accommodationinfobyid")]
        public IHttpActionResult GetAccommodationInfoById(int accommodationinfoid)
        {
            var accommodation = _bll.GetAccommodationInfoById(accommodationinfoid);
            if (accommodation == null) return BadRequest();
            return Ok(accommodation);
        }

        // GET: api/AccommodationInfo/AccommodationInfoByConferenceId?conferenceid=
        [HttpGet]
        [Route("api/accommodationinfo/accommodationinfobyconferenceid")]
        public IHttpActionResult GetAccommodationInfoByConferenceId(int conferenceid)
        {
            var accommodation = _bll.GetAccommodationInfoByConferenceId(conferenceid);
            if (accommodation == null) return BadRequest();
            return Ok(accommodation);
        }

        // POST: api/AccommodationInfo/AddAccommodationInfo
        [HttpPost]
        [Route("api/accommodationInfo/addaccommodationinfo")]
        public IHttpActionResult AddAccommodationInfo([FromBody] AccommodationInfoDTO accommodation)
        {
            if (string.IsNullOrEmpty(accommodation.PlaceName)) return BadRequest();
            if (_bll.AddAccommodationInfo(accommodation)) return Ok();
            return InternalServerError();
        }

        // PUT: api/AccommodationInfo/EditAccommodationInfo
        [HttpPut]
        [Route("api/accommodationinfo/editaccommodationinfo")]
        public IHttpActionResult EditAccommodationInfo([FromBody] AccommodationInfoDTO accommodation)
        {
            if (string.IsNullOrEmpty(accommodation.PlaceName)) return BadRequest();
            if (_bll.EditAccommodationInfo(accommodation)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/AccommodationInfo/DeleteAccommodationInfo?accommodationinfoId=
        [HttpDelete]
        [Route("api/accommodationinfo/deleteaccommodationinfo")]
        public IHttpActionResult DeleteAccommodationInfo(int accommodationinfoid)
        {
            if (_bll.DeleteAccommodationInfo(accommodationinfoid)) return Ok();
            return InternalServerError();
        }
    }
}