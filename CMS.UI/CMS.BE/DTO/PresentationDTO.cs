namespace CMS.BE.DTO
{
    public class PresentationDTO
    {
        public int PresentationId { get; set; }
        public int PresenterId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArticleId { get; set; }
        public int RoomId { get; set; }
        public int? SessionId { get; set; }
        public int? SpecialSessionId { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Grade { get; set; }

    }
}
