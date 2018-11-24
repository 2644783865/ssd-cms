namespace CMS.BE.DTO
{
    class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string Topic { get; set; }
        public int PresentationId { get; set; }
        public int SpecialSessionId { get; set; }
        public string Status { get; set; }
        public System.DateTime AcceptanceDate { get; set; }
        public int ConferenceID { get; set; }
    }
}
