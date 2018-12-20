namespace CMS.BE.DTO
{
    public class EventDTO: BaseEntryEntity
    {
        public int EventId { get; set; }
        public int ConferenceId { get; set; }
        public int? RoomId { get; set; }
        public string Description { get; set; }        
    }
}
