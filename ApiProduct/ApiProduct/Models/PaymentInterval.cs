using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduct.Models
{
    public class PaymentInterval
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public TimeSpan Interval { get; set; }
        public double Discount { get; set; }
    }
}
