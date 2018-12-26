namespace CMS.BE.DTO
{
    public class ConferenceDTO
    {
        public int ConferenceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }

        public string ConferenceDesc { get => $"{ConferenceId} {Title} {BeginDate.ToShortDateString()}"; }
    }
}
