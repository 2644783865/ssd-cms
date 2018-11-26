using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface IArticleRepository : IDisposable
    {
        //Article
        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticleById(int id);
        void AddArticle(ArticleDTO articleDTO);
        void EditArticle(ArticleDTO articleDTO);
        void DeleteArticle(int articleId);

        //Submission
        IEnumerable<SubmissionDTO> GetSubmissions();
        SubmissionDTO GetSubmissionById(int id);
        void AddSubmission(SubmissionDTO submissionDTO);
        void EditSubmission(SubmissionDTO submissionDTO);
        void DeleteSubmission(int submissionId);
    }
}
