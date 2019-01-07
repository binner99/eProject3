using System.ComponentModel.DataAnnotations;


namespace Data
{
    
    public class Service
    {
        
        [Key]
        [Display(Name = "Service ID")]
        public int sID { get; set; }

        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Service Name")]
        public string sName { get; set; }

        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string sDes { get; set; }

        
        [Required]
        [Range(100, 100000)]
        [Display(Name = "Price")]
        public double sPrice { get; set; }
    }
}
