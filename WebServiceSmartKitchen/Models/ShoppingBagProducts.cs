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
    
    public partial class ShoppingBagProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }
        public string Shop { get; set; }
    
        public virtual ShoppingBags ShoppingBags { get; set; }
    }
}