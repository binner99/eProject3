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
    class Admin
    {
        [DataMember]
        [Key]
        [Display(Name = "User name")]
        [StringLength(50, MinimumLength = 3)]
        public string adName { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string adPass { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Role")]
        public bool adRole { get; set; }

        [DataMember]
        [DataType(DataType.Upload)]
        public string adImage { get; set; }

    }
}
