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
    
    public partial class Grade
    {
        public Grade()
        {
            this.Presentations = new HashSet<Presentation>();
        }
    
        public int GradeId { get; set; }
        public int PresentationId { get; set; }
    
        public virtual Presentation Presentation { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
    }
}
