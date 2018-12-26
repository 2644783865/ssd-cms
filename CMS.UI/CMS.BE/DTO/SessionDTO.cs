using System;

namespace CMS.BE.DTO
{
    public class SessionDTO: BaseEntryEntity
    {
        public int SessionId { get; set; }
        public int ConferenceId { get; set; }
        public int ChairId { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }

        public string SessionDesc { get => $"{Title} {BeginDate}"; }
    }
}
