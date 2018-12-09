using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace CMS.API.DAL.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private cmsEntities _db = new cmsEntities();
        //Article
        public IEnumerable<ArticleDTO> GetArticles()
        {
            return _db.Articles.Project().To<ArticleDTO>();
        }

        public ArticleDTO GetArticleById(int articleId)
        {
            var article = _db.Articles.Find(articleId);
            if (article == null) return null;
            else return MapperExtension.mapper.Map<Article, ArticleDTO>(article);
        }

        public IEnumerable<ArticleDTO> GetArticlesForConferenceAndAuthor(int conferenceId, int authorId)
        {
            var articles = _db.Articles.SqlQuery("SELECT * FROM Article WHERE ArticleId IN " +
                "(SELECT * FROM Article JOIN ArticleAuthor ON Article.ArticleId = ArticleAuthor.ArticleId" +
                "WHERE ConferenceID = @conferenceId AND AuthorId = @authorId)", new SqlParameter("@conferenceId", conferenceId),
                new SqlParameter("@authorId", authorId));
            foreach (var article in articles)
            {
                yield return MapperExtension.mapper.Map<Article, ArticleDTO>(article);
            }
        }

        public IEnumerable<AuthorDTO> GetAuthorsFromArticleId(int articleId)
        {
            var authors = _db.Authors.SqlQuery("SELECT * FROM Author WHERE AuthorId IN " +
                "(SELECT AuthorId FROM Article JOIN ArticleAuthor" +
                " ON Article.ArticleId = ArticleAuthor.ArticleId WHERE Article.ArticleId = 1)");
            foreach (var author in authors)
            {
                yield return MapperExtension.mapper.Map<Author, AuthorDTO>(author);
            }
        }

        public void AddArticle(ArticleDTO articleDTO)
        {
            var article = MapperExtension.mapper.Map<ArticleDTO, Article>(articleDTO);
            _db.Articles.Add(article);
            _db.SaveChanges();
        }

        public void EditArticle(ArticleDTO articleDTO)
        {
            var article = MapperExtension.mapper.Map<ArticleDTO, Article>(articleDTO);
            _db.Entry(_db.Articles.Find(articleDTO.ArticleId)).CurrentValues.SetValues(article);
            _db.SaveChanges();
        }

        public void DeleteArticle(int articleId)
        {
            var article = _db.Articles.Find(articleId);
            _db.Articles.Remove(article);
            _db.SaveChanges();
        }

        public decimal GetLastArticleId()
        {
            return _db.Database.SqlQuery<decimal>("SELECT IDENT_CURRENT('Article')").FirstOrDefault();
        }

        //Submission
        public IEnumerable<SubmissionDTO> GetSubmissions()
        {
            return _db.Submissions.Project().To<SubmissionDTO>();
        }

        public IEnumerable<SubmissionDTO> GetSubmissionsForArticle(int articleId)
        {
            return _db.Submissions.Where(sub => sub.ArticleId==articleId).Project().To<SubmissionDTO>();
        }

        public SubmissionDTO GetSubmissionById(int submissionId)
        {
            var submission = _db.Submissions.Find(submissionId);
            if (submission == null) return null;
            else return MapperExtension.mapper.Map<Submission, SubmissionDTO>(submission);
        }

        public void AddSubmission(SubmissionDTO submissionDTO)
        {
            var submission = MapperExtension.mapper.Map<SubmissionDTO, Submission>(submissionDTO);
            _db.Submissions.Add(submission);
            _db.SaveChanges();
        }

        public void EditSubmission(SubmissionDTO submissionDTO)
        {
            var submission = MapperExtension.mapper.Map<SubmissionDTO, Submission>(submissionDTO);
            _db.Entry(_db.Submissions.Find(submissionDTO.SubmissionId)).CurrentValues.SetValues(submission);
            _db.SaveChanges();
        }

        public void DeleteSubmission(int submissionId)
        {
            var submission = _db.Submissions.Find(submissionId);
            _db.Submissions.Remove(submission);
            _db.SaveChanges();
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        //ArticleAuthor

        public void AddArticleAuthor(int articleId, int authorId)
        {
            _db.Database.ExecuteSqlCommand("INSERT INTO ArticleAuthor VALUES (@p0, @p1)",
                articleId, authorId);
        }

        public void DeleteArticleAuthor(int articleId, int authorId)
        {
            _db.Database.ExecuteSqlCommand("DELETE FROM ArticleAuthor WHERE ArticleId=@p0 AND AuthorId=@p1",
                articleId, authorId);
        }

    }
}
