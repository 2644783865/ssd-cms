using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Interfaces
{
    public interface IArticleCore : IDisposable
    {
        Task<List<ArticleDTO>> GetArticlesAsync();
        Task<ArticleDTO> GetArticleByIdAsync(int articleId);
        Task<bool> AddArticleAsync(ArticleDTO article);
        Task<bool> EditArticleAsync(ArticleDTO article);
        Task<bool> DeleteArticleAsync(int articleId);
    }
}
