using System;

namespace CMS.BE.DTO
{
    public class SpecialSessionDTO
    {
        public int SpecialSessionId { get; set; }
        public int ConferenceId { get; set; }
        public int ChairId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
