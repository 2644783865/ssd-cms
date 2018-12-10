using System;

namespace CMS.BE.DTO
{
    public class LastMessageDTO
    {
        public int PairId { get; set; }
        public int FirstId { get; set; }
        public int SecondId { get; set; }
        public DateTime LastDate { get; set; }
        public String LastMessage { get; set; }
        public int FirstIdReceived { get; set; }
        public int SecondIdReceived { get; set; }
       
    }
}
