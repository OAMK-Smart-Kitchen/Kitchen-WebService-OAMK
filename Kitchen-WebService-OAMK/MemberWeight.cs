//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kitchen_WebService_OAMK
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberWeight
    {
        public int Id { get; set; }
        public int memberID { get; set; }
        public string value { get; set; }
        public int date { get; set; }
    
        public virtual Members Members { get; set; }
    }
}
