using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class Kitchen
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string TemperatureFridge { get; set; }


        // Foreign Key
        [Required]
        public int AdminId { get; set; }
        public int ShoppingBagId { get; set; }
        // Navigation property
        //public Author Author { get; set; }
    }
}