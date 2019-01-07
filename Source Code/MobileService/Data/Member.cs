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
    class Member
    {
        [DataMember]
        [Key]
        [StringLength(11,MinimumLength =10)]
        [Display(Name ="Phone Number")]
        public string memPhone { get; set; }
        [DataMember]
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name")]
        public string memName { get; set; }
        [DataMember]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string memEmail { get; set; }
        [DataMember]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string memPass { get; set; }
    }
}
