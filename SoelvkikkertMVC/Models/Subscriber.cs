using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoelvkikkertMVC.Models
{
    public class Subscriber
    {

        public int ID { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public bool Active { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
