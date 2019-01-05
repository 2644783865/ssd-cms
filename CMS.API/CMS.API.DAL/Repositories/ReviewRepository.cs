using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<ReviewDTO> GetReviewInfo(int conferenceId)
        {
            return _db.Reviews.Where(r => r.Article.ConferenceID==conferenceId).Project().To<ReviewDTO>();
        }

        public ReviewDTO GetReviewById(int reviewId)
        {
            var review = _db.Reviews.Find(reviewId);
            if (review == null) return null;
            else return MapperExtension.mapper.Map<Review, ReviewDTO>(review);
        }

        public IEnumerable<ReviewDTO> GetReviewsByArticleId(int articleId)
        {
            var reviews = _db.Reviews.Where(review => review.ArticleId == articleId).ToList();
            foreach (var review in reviews)
            {
                yield return MapperExtension.mapper.Map<Review, ReviewDTO>(review);
            }
        }

        public void AddReview(ReviewDTO reviewDTO)
        {
            var review = MapperExtension.mapper.Map<ReviewDTO, Review>(reviewDTO);
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        public void EditReview(ReviewDTO reviewDTO)
        {
            var review = MapperExtension.mapper.Map<ReviewDTO, Review>(reviewDTO);
            _db.Entry(_db.Reviews.Find(reviewDTO.ReviewerId)).CurrentValues.SetValues(review);
            _db.SaveChanges();

        }

        public void DeleteReview(int reviewId)
        {
            var review = _db.Reviews.Find(reviewId);
            _db.Reviews.Remove(review);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
