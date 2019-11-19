using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLogin.Models
{
    public class Subscriber : Person
    {

        public int ID { get; set; }
        public bool Active { get; set; }
        public ICollection<Product> products { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

