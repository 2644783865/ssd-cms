namespace CMS.BE.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int ArticleId { get; set; }
        public int ReviewerId { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public decimal Grade { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}
