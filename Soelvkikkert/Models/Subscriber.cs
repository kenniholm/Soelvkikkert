using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class Subscriber
    {

        private Subscriber()
        {

        }

        private string Email { get; set; }
        [Key]
        private string PhoneNumber { get; set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }

        private bool active { get; set; }
        private string product { get; set; }


    }
}
