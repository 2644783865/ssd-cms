using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IReviewBLL
    {
        IEnumerable<ReviewDTO> GetReviewInfo();
        ReviewDTO GetReviewById(int id);
        bool AddReview(ReviewDTO review);
        bool EditReview(ReviewDTO review);
        bool DeleteReview(int reviewId);
    }
}
