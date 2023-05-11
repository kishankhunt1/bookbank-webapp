﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int Product_id { get; set; }
        [ForeignKey("Product_id")]
        [ValidateNever]
        public Product Product { get; set; }


        [Range(1, 1000, ErrorMessage = "Please Enter a Value Between 1 to 1000")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
