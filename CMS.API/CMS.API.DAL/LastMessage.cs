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
    
    public partial class LastMessage
    {
        public int PairID { get; set; }
        public int FirstId { get; set; }
        public int SecondId { get; set; }
        public System.DateTime LastDate { get; set; }
        public string LastMessage1 { get; set; }
        public bool firstIdReceived { get; set; }
        public bool secondIdReceived { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
    }
}
