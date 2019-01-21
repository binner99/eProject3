﻿using System.ComponentModel.DataAnnotations;


namespace Data
{
    
    public class Product
    {
        
        [Key]
        [Display(Name = "Product ID")]
        public int pID { get; set; }
        
        [Required]
        [StringLength(50,MinimumLength =3)]
        [Display(Name = "Product Name")]
        public string pName { get; set; }
        
        [Required]
        [Display(Name = "Product Type")]
        public bool pType { get; set; }
        
        [Display(Name = "Description")]
        public string pDes { get; set; }

        [Required]
        [Range(100, 100000)]
        [Display(Name = "Money Pay")]
        public double pMP { get; set; }

        [Required]
        [Range(100, 100000)]
        [Display(Name = "Money Received")]
        public double pMR { get; set; }
    }
}
