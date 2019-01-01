using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IArticleCore : IDisposable
    {
        Task<List<ArticleDTO>> GetArticlesAsync(int conferenceId);
        Task<ArticleDTO> GetArticleByIdAsync(int articleId);
        Task<List<AuthorDTO>> GetAuthorsFromArticleIdAsync(int articleId);
        Task<List<ArticleDTO>> GetArticlesForConferenceAndAuthorAsync(int conferenceId, int authorId);
        Task<List<ArticleDTO>> GetSubmittedArticlesAsync();
        Task<List<ArticleDTO>> GetRejectedArticlesAsync();
        Task<bool> AddArticleAsync(AddArticleModel articleModel);
        Task<bool> EditArticleAsync(ArticleDTO article);
        Task<bool> DeleteArticleAsync(int articleId);
        Task<bool> SetAuthorForArticleAsync(int articleId, int authorId);
        Task<bool> DeleteAssignmentAuthorForArticleAsync(int articleId, int authorId);

        Task<List<SubmissionDTO>> GetSubmissionsAsync();
        Task<SubmissionDTO> GetSubmissionByIdAsync(int submissionId);
        Task<List<SubmissionDTO>> GetSubmissionsForArticleAsync(int articleId);
        Task<bool> AddSubmissionAsync(SubmissionDTO submission);
        Task<bool> EditSubmissionAsync(SubmissionDTO submission);
        Task<bool> DeleteSubmissionAsync(int submissionId);
        Task<bool> AcceptArticleAsync(int articleId, int editorId);
        Task<bool> RejectArticleAsync(int articleId, int editorId);
    }
}
