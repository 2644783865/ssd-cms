using System;

namespace CMS.BE.DTO
{
    public class SpecialSessionDTO : BaseTimeEntity
    {
        public int SpecialSessionId { get; set; }
        public int ConferenceId { get; set; }
        public int ChairId { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }
        
    }
}
