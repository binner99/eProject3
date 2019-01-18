using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileServiceClient.Models
{
    public class PBpay
    {
        [Required]
        [Display(Name = "Bill Code")]
        public string BillCode { get; set; }
        [Required]
        [Range(100, 100000)]
        [Display(Name = "Amount")]
        public double Amount { get; set; }
    }
}