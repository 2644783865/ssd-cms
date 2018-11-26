using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

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

        public void AddArticle(ArticleDTO articleDTO)
        {
            var article = MapperExtension.mapper.Map<ArticleDTO, Article>(articleDTO);
            _db.Articles.Add(article);
            _db.SaveChanges();
        }

        public void EditArticle(ArticleDTO articleDTO)
        {
            var article = MapperExtension.mapper.Map<ArticleDTO, Article>(articleDTO);
            _db.Entry(article).CurrentValues.SetValues(article);
            _db.SaveChanges();
        }

        public void DeleteArticle(int articleId)
        {
            var article = _db.Articles.Find(articleId);
            _db.Articles.Remove(article);
            _db.SaveChanges();
        }
        //Submission
        public IEnumerable<SubmissionDTO> GetSubmissions()
        {
            return _db.Submissions.Project().To<SubmissionDTO>();
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
            _db.Entry(submission).CurrentValues.SetValues(submission);
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

    }
}
