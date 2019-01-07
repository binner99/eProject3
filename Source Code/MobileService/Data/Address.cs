using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    [DataContract]
    class Address
    {
        [DataMember]
        [Key]
        public int addressID { get; set; }

        [DataMember]
        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Company Name")]
        public string compName { get; set; }

        [DataMember]
        [Required]
        [StringLength(100, MinimumLength = 10)]
        [Display(Name = "Company Address")]
        public string compAdress { get; set; }

        [DataMember]
        [StringLength(200, MinimumLength = 10)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [DataMember]
        [DataType(DataType.Upload)]
        public string image { get; set; }
    }
}
