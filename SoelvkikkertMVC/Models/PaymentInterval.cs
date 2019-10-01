using System;
using System.ComponentModel.DataAnnotations;

namespace SoelvkikkertMVC.Models
{
    public class PaymentInterval
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public TimeSpan Interval { get; set; }
        public double Discount { get; set; }
    }
}
