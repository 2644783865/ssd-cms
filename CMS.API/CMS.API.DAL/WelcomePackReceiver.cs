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
    
    public partial class WelcomePackReceiver
    {
        public int WelcomePackReceiverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public bool GetGift { get; set; }
        public int ConferenceId { get; set; }
    
        public virtual Conference Conference { get; set; }
    }
}
