using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoelvkikkertMVC.Models
{
    public class Employee : Person
    {
        public int ID { get; set; }

        public bool Administrator { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
