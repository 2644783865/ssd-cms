//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.API.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Presentation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presentation()
        {
            this.Articles = new HashSet<Article>();
            this.Articles1 = new HashSet<Article>();
            this.Awards = new HashSet<Award>();
        }
    
        public int PresentationId { get; set; }
        public int ArticleId { get; set; }
        public int RoomId { get; set; }
        public Nullable<int> SessionId { get; set; }
        public Nullable<int> SpecialSessionId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles1 { get; set; }
        public virtual Article Article { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Award> Awards { get; set; }
        public virtual Room Room { get; set; }
        public virtual Session Session { get; set; }
        public virtual SpecialSession SpecialSession { get; set; }
    }
}
