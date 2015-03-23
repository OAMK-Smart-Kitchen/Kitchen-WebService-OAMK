using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class MemberLength
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int Date { get; set; }

        // Foreign Key
        [Required]
        public int MemberId { get; set; }
        // Navigation property
        //public Author Author { get; set; }
    }
}