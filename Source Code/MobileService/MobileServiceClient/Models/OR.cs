using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileServiceClient.Models
{
    public class OR
    {
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "Phone Number must [10-11] number.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Phone number must number.")]
        public string Phone { get; set; }
        [Required]
        [Range(100, 100000)]
        [Display(Name = "Amount")]
        public double Amount { get; set; }
        public IEnumerable<Product> Package { get; set; }

    }
}