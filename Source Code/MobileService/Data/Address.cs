
using System.ComponentModel.DataAnnotations;

namespace Data
{

    public class Address
    {

        [Key]
        public int addressID { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Company Name")]
        public string compName { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Company Address")]
        public string compAdress { get; set; }


        [StringLength(200, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string description { get; set; }


        [DataType(DataType.Upload)]
        public string image { get; set; }
    }
}
