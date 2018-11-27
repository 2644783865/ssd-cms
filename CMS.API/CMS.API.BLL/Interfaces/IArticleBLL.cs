using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IArticleBLL
    {
        //Article

        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticleById(int id);
        bool AddArticle(ArticleDTO article);
        bool EditArticle(ArticleDTO article);
        bool DeleteArticle(int articleId);

        //Submission

        IEnumerable<SubmissionDTO> GetSubmissions();
        SubmissionDTO GetSubmissionById(int id);
        bool AddSubmission(SubmissionDTO submission);
        bool EditSubmission(SubmissionDTO submission);
        bool DeleteSubmission(int submissionId);
    }
}
