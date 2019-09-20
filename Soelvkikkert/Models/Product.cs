using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Soelvkikkert.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscribtionStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscribtionEnd { get; set; }

        ICollection<PaymentInterval> PaymentIntervals { get; set; }

        public PaymentInterval SelectedPaymentInterval { get; set; }

        public int PaymentIntervalID { get; set; }
        public int SubscriberID { get; set; }

    }
}
