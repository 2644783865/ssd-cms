using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
    public interface IArticleBLL
    {
        IEnumerable<ArticleDTO> GetArticles();
        ArticleDTO GetArticleById(int id);
        bool AddArticle(ArticleDTO article);
        bool EditArticle(ArticleDTO article);
        bool DeleteArticle(int articleId);
    }
}
