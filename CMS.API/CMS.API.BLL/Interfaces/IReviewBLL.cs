using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IReviewBLL
    {
        IEnumerable<ReviewDTO> GetReviewInfo(int conferenceId);
        ReviewDTO GetReviewById(int id);
        bool AddReview(ReviewDTO review);
        bool EditReview(ReviewDTO review);
        bool DeleteReview(int reviewId);
        IEnumerable<ReviewDTO> GetReviewsByArticleId(int articleId);
    }
}
