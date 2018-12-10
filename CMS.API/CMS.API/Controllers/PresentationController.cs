using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class PresentationController : ApiController
    {
        private IPresentationBLL _bll = new PresentationBLL();
        /*
        // GET: api/Presentation/Presentation
        [HttpGet]
        [Route("api/presentation/presentation")]
        public IHttpActionResult GetPresentations()
        {
            return Ok(_bll.GetPresentations());
        }

        // GET: api/Presentation/GetPresentationById?presentationId=
        [HttpGet]
        [Route("api/presentation/getpresentationbyid")]
        public IHttpActionResult GetPresentationById(int presentationId)
        {
            var presentation = _bll.GetPresentationById(presentationId);
            if (presentation == null) return BadRequest();
            return Ok(presentation);
        }
        */
        // POST: api/Presentation/AddPresentation
        [HttpPost]
        [Route("api/presentation/addpresentation")]
        public IHttpActionResult AddPresentation([FromBody] PresentationDTO presentation)
        {
            if (string.IsNullOrEmpty(presentation.Title)
                || ((presentation.SessionId==null) ^ (presentation.SpecialSessionId == null))) return BadRequest();
            if (_bll.AddPresentation(presentation)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/EditPresentation
        [HttpPut]
        [Route("api/presentation/editpresentation")]
        public IHttpActionResult EditPresentation([FromBody] PresentationDTO presentation)
        {
            if (string.IsNullOrEmpty(presentation.Title)
                || ((presentation.SessionId == null) ^ (presentation.SpecialSessionId == null))) return BadRequest();
            if (_bll.EditPresentation(presentation)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Presentation/DeletePresentation?presentationId=
        [HttpDelete]
        [Route("api/presentation/deletepresentation")]
        public IHttpActionResult DeletePresentation(int presentationId)
        {
            if (_bll.DeletePresentation(presentationId)) return Ok();
            return InternalServerError();
        }
    }
}
