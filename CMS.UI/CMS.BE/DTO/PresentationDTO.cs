namespace CMS.BE.DTO
{
    public class PresentationDTO
    {
        public int PresentationId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int grade { get; set; }

    }
}
