﻿namespace CMS.BE.DTO
{
    public class SubmissionDTO
    {
        public int SubmissionId { get; set; }
        public int ArticleId { get; set; }
        public byte[] ArticleFile { get; set; }
        public System.DateTime SubmissionDate { get; set; }
    }
}
