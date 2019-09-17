using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class PaymentInterval
    {
        public int ID { get; set; }
        public TimeSpan Interval { get; set; }
        public double Discount { get; set; }
    }
}
