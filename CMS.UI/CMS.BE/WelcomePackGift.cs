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
    
    public partial class WelcomePackGift
    {
        public WelcomePackGift()
        {
            this.WelcomePackReceivers = new HashSet<WelcomePackReceiver>();
        }
    
        public int WelcomePackGiftId { get; set; }
        public int WelcomePackId { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
    
        public virtual WelcomePack WelcomePack { get; set; }
        public virtual ICollection<WelcomePackReceiver> WelcomePackReceivers { get; set; }
    }
}
