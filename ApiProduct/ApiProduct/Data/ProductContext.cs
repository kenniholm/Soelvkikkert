using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Models;

namespace ApiProduct.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentInterval> PaymentInterval { get; set; }

        public DbSet<Product> Product { get; set; }
    }
}
