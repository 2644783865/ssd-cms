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
    
    public partial class Award
    {
        public int AwardId { get; set; }
        public int PresentationId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Presentation Presentation { get; set; }
    }
}
