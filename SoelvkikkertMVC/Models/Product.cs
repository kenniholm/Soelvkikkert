using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoelvkikkertMVC.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        ICollection<PaymentInterval> PaymentIntervals { get; set; }
    }
}