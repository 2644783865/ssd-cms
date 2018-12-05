using CMS.BE.DTO;

namespace CMS.BE.Models.Article
{
    public class AddArticleModel
    {
        public ArticleDTO Article { get; set; }
        public int AuthorId { get; set; }
    }
}
