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
    
    public partial class Message
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public long GroupID { get; set; }
        public int SequenceNumber { get; set; }
        public string Content { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
    }
}
