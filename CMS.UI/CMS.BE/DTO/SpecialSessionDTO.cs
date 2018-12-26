using System;

namespace CMS.BE.DTO
{
    public class SpecialSessionDTO : BaseEntryEntity
    {
        public int SpecialSessionId { get; set; }
        public int ConferenceId { get; set; }
        public int ChairId { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }

        public string SpecialSessionDesc { get => $"{Title} {BeginDate}"; }

    }
}
