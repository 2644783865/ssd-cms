using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IReviewRepository : IDisposable
    {
        IEnumerable<ReviewDTO> GetReviewInfo();
        ReviewDTO GetReviewById(int id);
        IEnumerable<ReviewDTO> GetReviewsByArticleId(int articleId);
        void AddReview(ReviewDTO reviewDTO);
        void EditReview(ReviewDTO reviewDTO);
        void DeleteReview(int reviewId);
    }
}
