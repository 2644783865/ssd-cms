using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<ReviewDTO> GetReviewInfo()
        {
            return _db.Reviews.Project().To<ReviewDTO>();
        }

        public ReviewDTO GetReviewById(int reviewId)
        {
            var review = _db.Reviews.Find(reviewId);
            if (review == null) return null;
            else return MapperExtension.mapper.Map<Review, ReviewDTO>(review);
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
