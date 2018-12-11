namespace CMS.BE.DTO
{
    public class EventDTO: BaseTimeEntity
    {
        public int EventID { get; set; }
        public int ConferenceId { get; set; }
        public int? RoomId { get; set; }
        
        public string Description { get; set; }
        
    }
}
