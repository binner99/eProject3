using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract]
    public class Product
    {
        [DataMember]
        [Key]
        [Display(Name = "Product ID")]
        public int pID { get; set; }
        [DataMember]
        [Required]
        [StringLength(50,MinimumLength =3)]
        [Display(Name = "Product Name")]
        public string pName { get; set; }
        [DataMember]
        [Required]
        [Display(Name = "Product Type")]
        public bool pType { get; set; }
        [DataMember]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string pDes { get; set; }
        [DataMember]
        [Required]
        [Range(100,100000)]
        [Display(Name = "Price")]
        public double pPrice { get; set; }
    }
}
