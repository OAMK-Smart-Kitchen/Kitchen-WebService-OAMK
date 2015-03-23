using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class Members
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int dateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        public string pictureUrlk { get; set; }
        public string defaultColor { get; set; }
        public bool gameActivated { get; set; }
        public int gameHealthLevel { get; set; }
        public int gamePoints { get; set; }
        public string Password { get; set; }

        // Foreign Key
        [Required]
        public int KitchenId { get; set; }

        // Navigation property
        //public Kitchen Id { get; set; }
    }
}