﻿namespace CMS.BE.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public int ArticleId { get; set; }
        public int ReviewerId { get; set; }
        public System.DateTime ReviewDate { get; set; }
        public float Grade { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}