using System.ComponentModel.DataAnnotations;

namespace Data.Vo
{
    public class Login
    {
        [Key]
        [Required]
        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must be numeric")]
        public string memPhone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string memPass { get; set; }
    }
}