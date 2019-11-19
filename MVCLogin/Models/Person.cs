using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLogin.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
