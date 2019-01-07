using System.ComponentModel.DataAnnotations;

namespace Data
{
    
  public  class Admin
    {        
        [Key]
        [Display(Name = "User name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string adName { get; set; }

        
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string adPass { get; set; }

        
        [Required]
        [Display(Name = "Role")]
        public bool adRole { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public string adImage { get; set; }

    }
}
