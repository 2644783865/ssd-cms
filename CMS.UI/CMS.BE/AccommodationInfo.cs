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
    
    public partial class AccommodationInfo
    {
        public int AccommodationInfoId { get; set; }
        public int ConferenceId { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string City { get; set; }
        public string CityDesc { get; set; }
    
        public virtual Conference Conference { get; set; }
    }
}
