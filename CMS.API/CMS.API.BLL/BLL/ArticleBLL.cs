using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class ArticleBLL : IArticleBLL
    {
        private IArticleRepository _repository = new ArticleRepository();

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

        public bool AddArticle(ArticleDTO article)
        {
            try
            {
                _repository.AddArticle(article);
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
    }
}
