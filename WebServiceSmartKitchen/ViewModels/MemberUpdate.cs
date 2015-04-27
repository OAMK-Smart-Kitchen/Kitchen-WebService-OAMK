using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceSmartKitchen.Models;

namespace WebServiceSmartKitchen.ViewModels
{
    public class MemberUpdate
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public string GameActivated { get; set; }
        public string DefaultColor { get; set; }
    }
}