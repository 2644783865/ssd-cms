using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.BE.Models.Article;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class ArticleCore : IArticleCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<ArticleDTO>> GetArticlesAsync()
        {
            var path = $"{Properties.Resources.getArticlesPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<ArticleDTO>>(result.Content);
            }
            return null;
        }

        public async Task<ArticleDTO> GetArticleByIdAsync(int articleId)
        {
            var path = $"{Properties.Resources.getArticleByIdPath}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ArticleDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<AuthorDTO>> GetAuthorsForArticleAsync(int articleId)
        {
            var path = $"{Properties.Resources.getAuthorsForArticle}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AuthorDTO>>(result.Content);
            }
            else return null;
        }

        public async Task<List<ArticleDTO>> GetArticlesForConferenceAndAuthorAsync(int conferenceId, int authorId)
        {
            var path = $"{Properties.Resources.getArticlesForConferenceAndAuthorPath}?conferenceId={conferenceId}&authorId={authorId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<ArticleDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> AddArticleAsync(AddArticleModel articleModel)
        {
            var path = Properties.Resources.addArticlePath;
            var result = await _apiHelper.Post(path, articleModel);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditArticleAsync(ArticleDTO article)
        {
            var path = Properties.Resources.editArticlePath;
            var result = await _apiHelper.Put(path, article);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteArticleAsync(int articleId)
        {
            var path = $"{Properties.Resources.deleteArticlePath}?articleId={articleId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<List<SubmissionDTO>> GetSubmissionsAsync()
        {
            var path = $"{Properties.Resources.getSubmissionsPath}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<SubmissionDTO>>(result.Content);
            }
            return null;
        }

        public async Task<SubmissionDTO> GetSubmissionByIdAsync(int submissionId)
        {
            var path = $"{Properties.Resources.getSubmissionByIdPath}?submissionId={submissionId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<SubmissionDTO>(result.Content);
            }
            else return null;
        }

        public async Task<List<SubmissionDTO>> GetSubmissionsForArticleAsync(int articleId)
        {
            var path = $"{Properties.Resources.getSubmissionsForArticlePath}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<SubmissionDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> AddSubmissionAsync(SubmissionDTO submission)
        {
            var path = Properties.Resources.addSubmissionPath;
            var result = await _apiHelper.Post(path, submission);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> EditSubmissionAsync(SubmissionDTO submission)
        {
            var path = Properties.Resources.editSubmissionPath;
            var result = await _apiHelper.Put(path, submission);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteSubmissionAsync(int submissionId)
        {
            var path = $"{Properties.Resources.deleteSubmissionPath}?submissionId={submissionId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> AcceptArticleAsync(int articleId)
        {
            var path = $"{Properties.Resources.acceptArticlePath}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> RejectArticleAsync(int articleId)
        {
            var path = $"{Properties.Resources.rejectArticlePath}?articleId={articleId}";
            var result = await _apiHelper.Get(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> SetAuthorForArticleAsync(int articleId, int authorId)
        {
            var path = $"{Properties.Resources.setAuthorForArticlePath}?articleId={articleId}&authorId={authorId}";
            var result = await _apiHelper.Get(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteAssignmentAuthorForArticleAsync(int articleId, int authorId)
        {
            var path = $"{Properties.Resources.deleteAssignmentAuthorForArticlePath}?articleId={articleId}&authorId={authorId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public void Dispose() => _apiHelper.Dispose();
    }
}
