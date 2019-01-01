using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class EmergencyInfoController : ApiController
    {
        private IEmergencyInfoBLL _bll = new EmergencyInfoBLL();

        // GET: api/EmergencyInfo/EmergencyInfoInfo
        [HttpGet]
        [Route("api/emergencyinfo/emergencyinfoinfo")]
        public IHttpActionResult GetEmergencyInfoInfo()
        {
            return Ok(_bll.GetEmergencyInfoInfo());
        }

        // GET: api/EmergencyInfo/EmergencyInfoById?emergencyid=
        [HttpGet]
        [Route("api/emergencyinfo/emergencyinfobyid")]
        public IHttpActionResult GetEmergencyInfoById(int emergencyid)
        {
            var emergency = _bll.GetEmergencyInfoById(emergencyid);
            if (emergency == null) return BadRequest();
            return Ok(emergency);
        }

        // GET: api/EmergencyInfo/EmergencyInfoByConferenceId?conferenceid=
        [HttpGet]
        [Route("api/emergencyinfo/emergencyinfobyconferenceid")]
        public IHttpActionResult GetEmergencyInfoByConferenceId(int conferenceid)
        {
            var emergency = _bll.GetEmergencyInfoByConferenceId(conferenceid);
            if (emergency == null) return BadRequest();
            return Ok(emergency);
        }

        // POST: api/EmergencyInfo/AddEmergencyInfo
        [HttpPost]
        [Route("api/emergencyinfo/addemergencyinfo")]
        public IHttpActionResult AddEmergencyInfo([FromBody] EmergencyInfoDTO emergency)
        {
            if (_bll.AddEmergencyInfo(emergency)) return Ok();
            return InternalServerError();
        }

        // PUT: api/EmergencyInfo/EditEmergencyInfo
        [HttpPut]
        [Route("api/emergencyinfo/editemergencyinfo")]
        public IHttpActionResult EditEmergencyInfo([FromBody] EmergencyInfoDTO emergency)
        {
            if (_bll.EditEmergencyInfo(emergency)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/EmergencyInfo/DeleteEmergencyInfo?emergencyId=
        [HttpDelete]
        [Route("api/emergencyinfo/deletemergencyinfo")]
        public IHttpActionResult DeleteEmergencyInfo(int emergencyid)
        {
            if (_bll.DeleteEmergencyInfo(emergencyid)) return Ok();
            return InternalServerError();
        }
    }
}