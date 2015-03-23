using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class ProductsFridge
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string IdNFC { get; set; }
        public string Category { get; set; }
        public int Calories { get; set; }
        public string Address { get; set; }
        public string Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public bool Available { get; set; }

        // Foreign Key
        [Required]
        public int KitchenId { get; set; }
        public int AddedBy { get; set; }
        // Navigation property
        //public Author Author { get; set; }
    }
}