using System.ComponentModel.DataAnnotations;


namespace Data
{
    
    class Bill
    {
        
        [Key]
        public int billID { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string billPhone { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Customer Name")]
        public string billCusName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Bill Description")]
        public string billDes { get; set; }

        
        [Required]
        [Display(Name = "Bill Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime billDate { get; set; }

        
        [Required]
        [Range(100, 100000)]
        [Display(Name = "Total")]
        public double billTotal { get; set; }
    }
}
