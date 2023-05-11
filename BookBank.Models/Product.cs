using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBank.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }

        [Required]
        [Display(Name ="Title")]
        public string Product_Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Product_Description { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string Product_ISBN { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        public string Product_Author { get; set; }


        [Required]
        [Range(1, 10000)]
        [Display(Name = "List Price")]
        public double Product_ListPrice { get; set; }


        [Required]
        [Range(1,10000)]
        [Display(Name = "Price for 1-50")]
        public double Product_Price { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 51-100")]
        public double Product_Price50 { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Price for 100+")]
        public double Product_Price100 { get; set; }

        [Required]
        [ValidateNever]
        [Display(Name = "Product Image")]
        public string Product_ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }

    }
}
