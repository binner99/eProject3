using System.ComponentModel.DataAnnotations;


namespace Data
{
    
    class Payment
    {
        
        [Key]
        public int payID { get; set; }

        
        [Required]
        [StringLength(11, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string memPhone { get; set; }
        
        
        [Required]
        [Display(Name = "Card Number")]
        [StringLength(20,MinimumLength =10)]
        public string payCardNum { get; set; }

        
        [Required]
        [Display(Name = "Card Type")]
        [StringLength(20, MinimumLength = 10)]
        public string payType { get; set; }

        
        [Required]
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,ConvertEmptyStringToNull =true,DataFormatString ="{0:yyyy-MM-dd}")]
        public System.DateTime payExDate { get; set; }
    }
}
