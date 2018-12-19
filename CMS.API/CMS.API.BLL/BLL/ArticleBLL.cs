using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using CMS.BE.Models.Article;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.BLL.BLL
{
    //Article
    public class ArticleBLL : IArticleBLL
    {
        private IArticleRepository _repository = new ArticleRepository();
        private IPresentationRepository _presentationRepository = new PresentationRepository();

        public IEnumerable<ArticleDTO> GetArticles()
        {
            try
            {
                return _repository.GetArticles();
            }
            catch
            {
                return null;
            }
        }

        public ArticleDTO GetArticleById(int id)
        {
            try
            {
                var article = _repository.GetArticleById(id);
                if (article == null) return null;
                return article;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ArticleDTO> GetArticlesForConferenceAndAuthor(int conferenceId, int authorId)
        {
            try
            {
                var articles = _repository.GetArticlesForConferenceAndAuthor(conferenceId, authorId);
                if (articles == null) return null;
                return articles;
            }
            catch
            {
                return null;
            }
        }

        public bool AddArticle(AddArticleModel articleModel)
        {
            try
            {
                _repository.AddArticle(articleModel.Article);
                var articleId = (int)_repository.GetLastArticleId();
                _repository.AddArticleAuthor(articleId, articleModel.AuthorId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditArticle(ArticleDTO article)
        {
            try
            {
                _repository.EditArticle(article);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteArticle(int articleId)
        {
            try
            {
                _repository.DeleteArticle(articleId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AcceptArticle(int articleId)
        {
            try
            {
                var article = _repository.GetArticleById(articleId);
                article.Status = "accepted";
                article.AcceptanceDate = System.DateTime.Now;
                var presentation = new PresentationDTO()
                {
                    PresenterId = _repository.GetAuthorsFromArticleId(articleId).First().AccountId,
                    Title = article.Topic,
                    ArticleId = article.ArticleId
                };
                _repository.EditArticle(article);
                _presentationRepository.AddPresentation(presentation);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool RejectArticle(int articleId)
        {
            try
            {
                var article = _repository.GetArticleById(articleId);
                article.Status = "rejected";
                _repository.EditArticle(article);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<AuthorDTO> GetAuthorsFromArticleId(int articleId)
        {
            try
            {
                return _repository.GetAuthorsFromArticleId(articleId);
            }
            catch
            {
                return null;
            }
        }

        //Submission

        public IEnumerable<SubmissionDTO> GetSubmissions()
        {
            try
            {
                return _repository.GetSubmissions();
            }
            catch
            {
                return null;
            }
        }

        public SubmissionDTO GetSubmissionById(int id)
        {
            try
            {
                var submission = _repository.GetSubmissionById(id);
                if (submission == null) return null;
                return submission;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<SubmissionDTO> GetSubmissionsForArticle(int articleId)
        {
            try
            {
                return _repository.GetSubmissionsForArticle(articleId).OrderByDescending(s => s.SubmissionDate);
            }
            catch
            {
                return null;
            }
        }

        public bool AddSubmission(SubmissionDTO submission)
        {
            try
            {
                _repository.AddSubmission(submission);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditSubmission(SubmissionDTO submission)
        {
            try
            {
                _repository.EditSubmission(submission);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteSubmission(int submissionId)
        {
            try
            {
                _repository.DeleteSubmission(submissionId);
            }
            catch
            {
                return false;
            }
            return true;
        }


        //ArticleAuthor

        public bool SetAuthorForArticle(int articleId, int authorId)
        {
            try
            {
                _repository.AddArticleAuthor(articleId, authorId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAssignmentAuthorForArticle(int articleId, int authorId)
        {
            try
            {
                _repository.DeleteArticleAuthor(articleId, authorId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
