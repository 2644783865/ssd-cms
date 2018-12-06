using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class AuthorController : ApiController
    {
        private IAuthorBLL _bll = new AuthorBLL();

        // GET: api/Author/Authors
        [HttpGet]
        [Route("api/author/authors")]
        public IHttpActionResult GetAuthors()
        {
            return Ok(_bll.GetAuthors());
        }

        // GET: api/Author/AuthorByAccountId?accountId=
        [HttpGet]
        [Route("api/author/authorbyaccountid")]
        public IHttpActionResult GetAuthorByAccountId(int accountId)
        {
            var author = _bll.GetAuthorByAccountId(accountId);
            if (accountId == null) return BadRequest();
            return Ok(author);
        }

        // GET: api/Author/AuthorById?authorid=
        [HttpGet]
        [Route("api/author/authorbyid")]
        public IHttpActionResult GetAuthorById(int authorid)
        {
            var author = _bll.GetAuthorById(authorid);
            if (author == null) return BadRequest();
            return Ok(author);
        }

        // POST: api/Author/AddAuthor
        [HttpPost]
        [Route("api/author/addauthor")]
        public IHttpActionResult AddAuthor([FromBody] AuthorDTO author)
        {
            if (string.IsNullOrEmpty(author.FirstName) || string.IsNullOrEmpty(author.LastName)
                || string.IsNullOrEmpty(author.FieldOfStudy)) return BadRequest();
            if (_bll.AddAuthor(author)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Author/EditAuthor
        [HttpPut]
        [Route("api/author/editauthor")]
        public IHttpActionResult EditAuthor([FromBody] AuthorDTO author)
        {
            if (string.IsNullOrEmpty(author.FirstName) || string.IsNullOrEmpty(author.LastName)
                || string.IsNullOrEmpty(author.FieldOfStudy)) return BadRequest();
            if (_bll.EditAuthor(author)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Author/DeleteAuthor?authorid=
        [HttpDelete]
        [Route("api/author/deleteauthor")]
        public IHttpActionResult DeleteAuthor(int authorid)
        {
            if (_bll.DeleteAuthor(authorid)) return Ok();
            return InternalServerError();
        }
    }
}