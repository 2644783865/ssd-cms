﻿using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class ArticleController : ApiController
    {
        private IArticleBLL _bll = new ArticleBLL();

        // GET: api/Article/Articles?conferenceId=
        [HttpGet]
        [Route("api/article/articles")]
        public IHttpActionResult GetArticles(int conferenceId)
        {
            return Ok(_bll.GetArticles(conferenceId));
        }

        // GET: api/Article/ArticleById?articleid=
        [HttpGet]
        [Route("api/article/articlebyid")]
        public IHttpActionResult GetArticleById(int articleid)
        {
            var article = _bll.GetArticleById(articleid);
            if (article == null) return BadRequest();
            return Ok(article);
        }

        // GET: api/Article/ArticlesForConferenceAndAuthor?conferenceId=?authorId=
        [HttpGet]
        [Route("api/article/articlesforconferenceandauthor")]
        public IHttpActionResult GetArticlesForConferenceAndAuthor(int conferenceId, int authorId)
        {
            var article = _bll.GetArticlesForConferenceAndAuthor(conferenceId, authorId);
            if (article == null) return BadRequest();
            return Ok(article);
        }

        // GET: api/Article/AuthorsFromArticleId
        [HttpGet]
        [Route("api/article/authorsfromarticleid")]
        public IHttpActionResult GetAuthorsFromArticleId(int articleId)
        {
            return Ok(_bll.GetAuthorsFromArticleId(articleId));
        }

        // POST: api/Article/AddArticle
        [HttpPost]
        [Route("api/article/addarticle")]
        public IHttpActionResult AddArticle([FromBody] AddArticleModel articleModel)
        {
            if (string.IsNullOrEmpty(articleModel.Article.Topic) || string.IsNullOrEmpty(articleModel.Article.Status)) return BadRequest();
            if (_bll.AddArticle(articleModel)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Article/EditArticle
        [HttpPut]
        [Route("api/article/editarticle")]
        public IHttpActionResult EditArticle([FromBody] ArticleDTO article)
        {
            if (string.IsNullOrEmpty(article.Topic) || string.IsNullOrEmpty(article.Status)) return BadRequest();
            if (_bll.EditArticle(article)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Article/DeleteArticle?articleid=
        [HttpDelete]
        [Route("api/article/deletearticle")]
        public IHttpActionResult DeleteArticle(int articleid)
        {
            if (_bll.DeleteArticle(articleid)) return Ok();
            return InternalServerError();
        }

        // GET: api/Article/AcceptArticle?articleId=&editorId=
        [HttpGet]
        [Route("api/article/acceptarticle")]
        public IHttpActionResult AcceptArticle(int articleId, int editorId)
        {
            if (articleId == 0) return BadRequest();
            if (_bll.AcceptArticle(articleId, editorId)) return Ok();
            return InternalServerError();
        }

        // GET: api/Article/RejectArticle?articleId=&editorId=
        [HttpGet]
        [Route("api/article/rejectarticle")]
        public IHttpActionResult RejectArticle(int articleId, int editorId)
        {
            if (articleId == 0) return BadRequest();
            if (_bll.RejectArticle(articleId, editorId)) return Ok();
            return InternalServerError();
        }


        // GET: api/Submission/SubmittedArticles
        [HttpGet]
        [Route("api/submission/submittedarticles")]
        public IHttpActionResult GetSubmittedArticles()
        {
            return Ok(_bll.GetSubmittedArticles());
        }

        // GET: api/Submission/RejectedArticles
        [HttpGet]
        [Route("api/submission/rejectedarticles")]
        public IHttpActionResult GetRejectedArticles()
        {
            return Ok(_bll.GetRejectedArticles());
        }

        // GET: api/Submission/Submissions
        [HttpGet]
        [Route("api/submission/submissions")]
        public IHttpActionResult GetSubmissions()
        {
            return Ok(_bll.GetSubmissions());
        }

        // GET: api/Submission/SubmissionById?submissionid=
        [HttpGet]
        [Route("api/submission/submissionbyid")]
        public IHttpActionResult GetSubmissionById(int submissionid)
        {
            var submission = _bll.GetSubmissionById(submissionid);
            if (submission == null) return BadRequest();
            return Ok(submission);
        }

        // GET: api/Submission/SubmissionsForArticle
        [HttpGet]
        [Route("api/submission/submissionsforarticle")]
        public IHttpActionResult GetSubmissionsForArticle(int articleId)
        {
            return Ok(_bll.GetSubmissionsForArticle(articleId));
        }

        // POST: api/Submission/AddSubmission
        [HttpPost]
        [Route("api/submission/addsubmission")]
        public IHttpActionResult AddSubmission([FromBody] SubmissionDTO submission)
        {
            if (submission.ArticleFile == null) return BadRequest();
            if (_bll.AddSubmission(submission)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Submission/EditSubmission
        [HttpPut]
        [Route("api/submission/editsubmission")]
        public IHttpActionResult EditSubmission([FromBody] SubmissionDTO submission)
        {
            if (submission.ArticleFile != null) return BadRequest();
            if (_bll.EditSubmission(submission)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Submission/DeleteSubmission?submissionId=
        [HttpDelete]
        [Route("api/submission/deletesubmission")]
        public IHttpActionResult DeleteSubmission(int submissionid)
        {
            if (_bll.DeleteSubmission(submissionid)) return Ok();
            return InternalServerError();
        }

        // POST: api/Article/SetAuthorForArticle?articleId=&authorId
        [HttpPost]
        [Route("api/article/setauthorforarticle")]
        public IHttpActionResult SetAuthorForArticle(int articleId, int authorId)
        {
            if (articleId == 0 || authorId == 0) return BadRequest();
            if (_bll.SetAuthorForArticle(articleId, authorId)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Article/DeleteAssignmentAuthorForArticle?articleId=&authorId
        [HttpDelete]
        [Route("api/article/deleteassignmentauthorforarticle")]
        public IHttpActionResult DeleteAssignmentAuthorForArticle(int articleId, int authorId)
        {
            if (articleId == 0 || authorId == 0) return BadRequest();
            if (_bll.DeleteAssignmentAuthorForArticle(articleId, authorId)) return Ok();
            return InternalServerError();
        }
    }
}