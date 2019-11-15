using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCLogin.Models
{
    public class SubscriberProduct
    {
        public int ProductID { get; set; }
        public int SubscriberID { get; set; }
        public int PaymentIntervalID { get; set; }
        public PaymentInterval SelectedPaymentInterval { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscriptionStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscriptionEnd { get; set; }
    }
}
