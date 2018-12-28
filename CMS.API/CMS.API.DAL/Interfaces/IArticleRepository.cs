using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IArticleRepository : IDisposable
    {
        //Article
        IEnumerable<ArticleDTO> GetArticles(int conferenceId);
        ArticleDTO GetArticleById(int id);
        void AddArticle(ArticleDTO articleDTO);
        void EditArticle(ArticleDTO articleDTO);
        void DeleteArticle(int articleId);
        decimal GetLastArticleId();
        IEnumerable<ArticleDTO> GetArticlesForConferenceAndAuthor(int conferenceId, int authorId);
        IEnumerable<AuthorDTO> GetAuthorsFromArticleId(int articleId);
        IEnumerable<ArticleDTO> GetSubmittedArticles();
        IEnumerable<ArticleDTO> GetRejectedArticles();
        //Submission
        IEnumerable<SubmissionDTO> GetSubmissions();
        IEnumerable<SubmissionDTO> GetSubmissionsForArticle(int articleId);
        SubmissionDTO GetSubmissionById(int id);
        void AddSubmission(SubmissionDTO submissionDTO);
        void EditSubmission(SubmissionDTO submissionDTO);
        void DeleteSubmission(int submissionId);

        //ArticleAuthor
        void AddArticleAuthor(int articleId, int authorId);
        void DeleteArticleAuthor(int articleId, int authorId);
    }
}
