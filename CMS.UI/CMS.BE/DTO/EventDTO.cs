﻿namespace CMS.BE.DTO
{
    public class EventDTO
    {
        public int EventID { get; set; }
        public int ConferenceId { get; set; }
        public int? RoomId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
    }
}
