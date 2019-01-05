using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class ReviewCore :IReviewCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<ReviewDTO>> GetReviewInfoAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getReviewInfoPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<ReviewDTO>>(result.Content);
            }
            return null;
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(int reviewId)
        {
            var path = $"{Properties.Resources.getReviewByIdPath}?reviewId={reviewId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ReviewDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<ReviewDTO>> GetReviewsByArticleIdAsync(int articleId)
        {
            var path = $"{Properties.Resources.getReviewsByArticleIdPath}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<ReviewDTO>>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddReviewAsync(ReviewDTO review)
        {
            var path = Properties.Resources.addReviewPath;
            var result = await _apiHelper.Post(path, review);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditReviewAsync(ReviewDTO review)
        {
            var path = Properties.Resources.editReviewPath;
            var result = await _apiHelper.Put(path, review);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var path = $"{Properties.Resources.deleteReviewPath}?reviewId={reviewId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
