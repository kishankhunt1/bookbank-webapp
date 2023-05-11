﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.Models
{
    public class Companies
    {
        public int Id { get;set;}
        [Required]
        public string Name { get;set;}
        [DisplayName("Address")]
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DisplayName("Postal Code")]
        public int? PostalCode { get; set; }
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get;set; }
    }
}
