﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceSmartKitchen.Models;

namespace WebServiceSmartKitchen.ViewModels
{
    public class MemberUpdate
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public string GameActivated { get; set; }
        public string DefaultColor { get; set; }
        public string GamePoints { get; set; }
        public string Gender { get; set; }
        public string AgeCategory { get; set; }
    }
}