
using System.ComponentModel.DataAnnotations;

namespace Data
{
    
   public class Feedback
    {
        
        [Key]
        public int fbID { get; set; }

        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string fbCusname { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string memPhone { get; set; }

        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string memEmail { get; set; }

        
        [Required]
        [Display(Name = "Object")]
        public bool fbObject { get; set; }

        [Required]
        [StringLength(1000,MinimumLength = 10)]
        [Display(Name = "Content")]
        public string fbContent { get; set; }

        
        [Required]
        [Display(Name = "Status")]
        public bool fbStatus { get; set; }
    }
}
