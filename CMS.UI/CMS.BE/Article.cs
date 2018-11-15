//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.BE
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public Article()
        {
            this.Presentations = new HashSet<Presentation>();
            this.Reviews = new HashSet<Review>();
            this.Submissions = new HashSet<Submission>();
        }
    
        public int ArticleId { get; set; }
        public Nullable<int> PresentationId { get; set; }
        public Nullable<int> SpecialSessionId { get; set; }
        public string ArticleTopic { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> AcceptanceDate { get; set; }
        public int ConferenceID { get; set; }
    
        public virtual Presentation Presentation { get; set; }
        public virtual SpecialSession SpecialSession { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual Author Author { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
