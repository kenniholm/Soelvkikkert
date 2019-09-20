using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class Subscriber
    {

        public int ID { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [RegularExpression(@"^[+]?\d{8,10}$")]
        public string PhoneNumber { get; set; }

        [Required]
        // This regular expression should a name with a large start Peter but not peter
        [RegularExpression(@"^([A-Z|Æ|Ø|Å]{1})([a-z|æ|ø|å])*$")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        // This regular expression should a name with a large start Peter but not peter
        [RegularExpression(@"^([A-Z|Æ|Ø|Å]{1})([a-z|æ|ø|å])*$")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public bool Active { get; set; }
        public ICollection<Product> products { get; set; }





    }
}
