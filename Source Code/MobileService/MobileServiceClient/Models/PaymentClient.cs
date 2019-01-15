using System;
using System.ComponentModel.DataAnnotations;

namespace MobileServiceClient.Models
{
    public class PaymentClient
    {
        [Required]
        [Display(Name = "Name On Card")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        public string NumCard { get; set; }
        [Required]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]        
        public string ExDate { get; set; }

    }
}