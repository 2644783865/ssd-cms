using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System;
using System.Collections.ObjectModel;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class ArticleController : ApiController
    {
        private IArticleBLL _bll = new ArticleBLL();

        // GET: api/Article/Articles
        [HttpGet]
        [Route("api/article/articles")]
        public IHttpActionResult GetArticles()
        {
            return Ok(_bll.GetArticles());
        }

        // GET: api/Article/ArticlesForConferenceAndAuthor
        [HttpGet]
        [Route("api/article/articlesforconferenceandauthor")]
        public IHttpActionResult GetArticlesForConferenceAndAuthor(int conferenceId, int authorId)
        {
            var article = _bll.GetArticlesForConferenceAndAuthor(conferenceId, authorId);
            if (article == null) return BadRequest();
            return Ok(article);
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

        // GET: api/Submission/Submissions
        [HttpGet]
        [Route("api/submission/submissions")]
        public IHttpActionResult GetSubmissions()
        {
            return Ok(_bll.GetSubmissions());
        }

        // GET: api/Submission/SubmissionsForArticle
        [HttpGet]
        [Route("api/submission/submissionsforarticle")]
        public IHttpActionResult GetSubmissionsForArticle(int articleId)
        {
            return Ok(_bll.GetSubmissionsForArticle(articleId));
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
    }
}