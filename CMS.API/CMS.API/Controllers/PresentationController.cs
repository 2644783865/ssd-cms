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

        // PUT: api/Presentation/EditGradeOfPresentation?presentationId=&grade=
        [HttpPut]
        [Route("api/presentation/editgradeofpresentation")]
        public IHttpActionResult EditGradeOfPresentation(int presentationId, int grade)
        {
            if (_bll.EditGradeOfPresentation(presentationId, grade)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/DeleteGradeFromPresentation?presentationId=
        [HttpPut]
        [Route("api/presentation/deletegradefrompresentation")]
        public IHttpActionResult DeleteGradeFromPresentation(int presentationId)
        {
            if (_bll.DeleteGradeFromPresentation(presentationId)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/editsessionofpresentation?presentationId=&sessionId=
        [HttpPut]
        [Route("api/presentation/EditSessionOfPresentation")]
        public IHttpActionResult EditSessionOfPresentation(int presentationId, int sessionId)
        {
            if (_bll.EditSessionOfPresentation(presentationId, sessionId)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/EditSpecialSessionOfPresentation?presentationId=&specialSessionId=
        [HttpPut]
        [Route("api/presentation/editspecialsessionofpresentation")]
        public IHttpActionResult EditSpecialSessionOfPresentation(int presentationId, int specialSessionId)
        {
            if (_bll.EditSpecialSessionOfPresentation(presentationId, specialSessionId)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/DeleteSessionFromPresentation?presentationId=
        [HttpPut]
        [Route("api/presentation/deletesessionfrompresentation")]
        public IHttpActionResult DeleteSessionFromPresentation(int presentationId)
        {
            if (_bll.DeleteSessionFromPresentation(presentationId)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/DeleteSpecialSessionFromPresentation?presentationId=
        [HttpPut]
        [Route("api/presentation/deletespecialsessionfrompresentation")]
        public IHttpActionResult DeleteSpecialSessionFromPresentation(int presentationId)
        {
            if (_bll.DeleteSpecialSessionFromPresentation(presentationId)) return Ok();
            return InternalServerError();
        }

    }
}
