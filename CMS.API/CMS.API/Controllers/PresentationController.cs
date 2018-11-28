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
            if (string.IsNullOrEmpty(presentation.PresenterId) || string.IsNullOrEmpty(presentation.Title)
                || string.IsNullOrEmpty(presentation.ArticleId) || string.IsNullOrEmpty(presentation.RoomId)
                || (string.IsNullOrEmpty(presentation.SessionId) ^ string.IsNullOrEmpty(presentation.SpecialSessionId))
                || presentation.BeginDate == default(DateTime) || presentation.EndDate == default(DateTime)) return BadRequest();
            if (_bll.AddPresentation(presentation)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Presentation/EditPresentation
        [HttpPut]
        [Route("api/presentation/editpresentation")]
        public IHttpActionResult EditPresentation([FromBody] PresentationDTO presentation)
        {
            if (string.IsNullOrEmpty(presentation.PresenterId) || string.IsNullOrEmpty(presentation.Title)
                || string.IsNullOrEmpty(presentation.ArticleId) || string.IsNullOrEmpty(presentation.RoomId)
                || (string.IsNullOrEmpty(presentation.SessionId) ^ string.IsNullOrEmpty(presentation.SpecialSessionId))
                || presentation.BeginDate == default(DateTime) || presentation.EndDate == default(DateTime)) return BadRequest();
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
