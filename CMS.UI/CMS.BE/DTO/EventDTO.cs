namespace CMS.BE.DTO
{
    public class EventDTO
    {
        public string EventID { get; set; }
        public string ConferenceId { get; set; }
        public string RoomId { get; set; }
        public string Title { get; set; }
        public string Desacription { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
