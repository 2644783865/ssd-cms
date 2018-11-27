using System;

namespace CMS.BE.DTO
{
    public class MessageDTO
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int GroupID { get; set; }
        public int SequenceNumber { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
       
    }
}
