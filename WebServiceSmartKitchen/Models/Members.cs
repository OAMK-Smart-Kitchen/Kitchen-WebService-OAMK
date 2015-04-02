//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceSmartKitchen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Members
    {
        public Members()
        {
            this.GameActivated = "True";
            this.MemberLength = new HashSet<MemberLength>();
            this.MemberWeight = new HashSet<MemberWeight>();
        }
    
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        public string DefaultColor { get; set; }
        public string Active { get; set; }
        public string GameActivated { get; set; }
        public string GameHealthLevel { get; set; }
        public string GamePoints { get; set; }
        public string Password { get; set; }
        public string Admin { get; set; }
    
        public virtual ICollection<MemberLength> MemberLength { get; set; }
        public virtual ICollection<MemberWeight> MemberWeight { get; set; }
        public virtual Kitchen Kitchen { get; set; }
    }
}
