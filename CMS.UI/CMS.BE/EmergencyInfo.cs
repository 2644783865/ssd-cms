//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.BE
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmergencyInfo
    {
        public int EmergencyInfoId { get; set; }
        public int ConferenceId { get; set; }
        public string EmergencyNum { get; set; }
        public string EmergencyInfo1 { get; set; }
    
        public virtual Conference Conference { get; set; }
    }
}
