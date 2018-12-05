using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IReviewCore : IDisposable
    {
        Task<List<ReviewDTO>> GetReviewInfoAsync();
        Task<ReviewDTO> GetReviewByIdAsync(int reviewId);
        Task<bool> AddReviewAsync(ReviewDTO review);
        Task<bool> EditReviewAsync(ReviewDTO review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
