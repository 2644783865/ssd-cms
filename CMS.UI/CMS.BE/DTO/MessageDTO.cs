using System;

namespace CMS.BE.DTO
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
       
    }
}
