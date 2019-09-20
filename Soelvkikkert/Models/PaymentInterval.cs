using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class PaymentInterval
    {
        public int ID { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Interval { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double Discount { get; set; }
    }
}
