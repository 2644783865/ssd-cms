using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IArticleBLL
    {
        //Article

        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticleById(int id);
        IEnumerable<ArticleDTO> GetArticlesForConferenceAndAuthor(int conferenceId, int authorId);
        bool AddArticle(AddArticleModel articleModel);
        bool EditArticle(ArticleDTO article);
        bool DeleteArticle(int articleId);
        bool AcceptArticle(int articleId);
        bool RejectArticle(int articleId);

        //Submission

        IEnumerable<SubmissionDTO> GetSubmissions();
        SubmissionDTO GetSubmissionById(int id);
        IEnumerable<SubmissionDTO> GetSubmissionsForArticle(int articleId);
        bool AddSubmission(SubmissionDTO submission);
        bool EditSubmission(SubmissionDTO submission);
        bool DeleteSubmission(int submissionId);

        //ArticleAuthor
        bool SetAuthorForArticle(int articleId, int authorId);
        bool DeleteAssignmentAuthorForArticle(int articleId, int authorId);
    }
}
