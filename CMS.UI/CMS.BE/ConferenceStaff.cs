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
    
    public partial class ConferenceStaff
    {
        public int ConferenceStaffId { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public int ConferenceId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Role Role { get; set; }
    }
}
