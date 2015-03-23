using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class ShoppingBagProducts
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }
        public string Shop { get; set; }

        // Foreign Key
        [Required]
        public int ShoppingBagId { get; set; }
        [Required]
        public int AddedBy { get; set; }
        // Navigation property
        //public Author Author { get; set; }
    }
}