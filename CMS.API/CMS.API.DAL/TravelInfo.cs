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
    
    public partial class TravelInfo
    {
        public int TravelInfoId { get; set; }
        public int ConferenceId { get; set; }
        public string Title { get; set; }
        public string AirportRoad { get; set; }
        public Nullable<int> AirportRoadTime { get; set; }
        public string RailwayRoad { get; set; }
        public Nullable<int> RailwayRoadTime { get; set; }
        public string TaxiNum { get; set; }
    
        public virtual Conference Conference { get; set; }
    }
}
