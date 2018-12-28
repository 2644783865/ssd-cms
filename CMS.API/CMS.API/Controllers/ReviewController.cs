using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class ReviewController : ApiController
    {
        private IReviewBLL _bll = new ReviewBLL();

        // GET: api/Review/Reviews
        [HttpGet]
        [Route("api/review/reviews")]
        public IHttpActionResult GetReviewInfo()
        {
            return Ok(_bll.GetReviewInfo());
        }

        // GET: api/Review/ReviewById?reviewid=
        [HttpGet]
        [Route("api/review/reviewbyid")]
        public IHttpActionResult GetReviewById(int reviewid)
        {
            var review = _bll.GetReviewById(reviewid);
            if (review == null) return BadRequest();
            return Ok(review);
        }

        // GET: api/Review/ReviewsByArticleId?articleId=
        [HttpGet]
        [Route("api/review/reviewsbyarticleid")]
        public IHttpActionResult GetReviewsByArticleId(int articleId)
        {
            var reviews = _bll.GetReviewsByArticleId(articleId);
            if (reviews == null) return BadRequest();
            return Ok(reviews);
        }

        // POST: api/Review/AddReview
        [HttpPost]
        [Route("api/review/addreview")]
        public IHttpActionResult AddReview([FromBody] ReviewDTO review)
        {
            if (string.IsNullOrEmpty(review.Title)) return BadRequest();
            if (_bll.AddReview(review)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Review/EditReview
        [HttpPut]
        [Route("api/review/editreview")]
        public IHttpActionResult EditReview([FromBody] ReviewDTO review)
        {
            if (string.IsNullOrEmpty(review.Title)) return BadRequest();
            if (_bll.EditReview(review)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Review/DeleteReview?reviewid=
        [HttpDelete]
        [Route("api/review/deletereview")]
        public IHttpActionResult DeleteReview(int reviewid)
        {
            if (_bll.DeleteReview(reviewid)) return Ok();
            return InternalServerError();
        }
    }
}