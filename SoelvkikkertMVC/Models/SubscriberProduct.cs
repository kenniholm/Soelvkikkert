using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoelvkikkertMVC.Models
{
    public class SubscriberProduct
    {
       public int ProductID { get; set; }
       public int SubscriberID { get; set; }

       public int PaymentIntervalID { get; set; }

       public PaymentInterval SelectedPaymentInterval { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubscribtionStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SubscribtionEnd { get; set; }
    }
}
