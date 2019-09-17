using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class Subscriber
    {

        public string Email { get; set; }
        [Key]
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Active { get; set; }
        public string Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubscribtionStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscribtionEnd { get; set; }


        public Subscriber(string _email, string _phoneNumber, string _firstName, string _lastName, bool _active, string _product, DateTime _subscribtionStart, DateTime _subscribtionEnd)
        {
            Email = _email;
            PhoneNumber = _phoneNumber;
            FirstName = _firstName;
            LastName = _lastName;
            Active = _active;
            Product = _product;
            SubscribtionStart = _subscribtionStart;
            SubscribtionEnd = _subscribtionEnd;
        }
    }
}
