
using System.ComponentModel.DataAnnotations;

namespace Data
{
    
   public class Member
    {
        
        [Key]
        [Required]
        [StringLength(11,MinimumLength =10)]
        [Display(Name ="Phone Number")]
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
    }
}
