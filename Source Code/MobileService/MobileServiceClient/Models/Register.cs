using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileServiceClient.Models
{
    public class Register
    {

        [Key]
        [Required]
        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must be numeric")]
        public string memPhone { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string memName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string memEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string memPass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("memPass")]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Confirm Password")]
        public string memConfirmPass { get; set; }
    }
}
