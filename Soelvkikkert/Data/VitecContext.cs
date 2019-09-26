using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Soelvkikkert.Models;

namespace Soelvkikkert.Models
{
    public class VitecContext : DbContext
    {
        public VitecContext (DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<Soelvkikkert.Models.Product> Product { get; set; }

        public DbSet<Soelvkikkert.Models.Subscriber> Subscriber { get; set; }

        public DbSet<Soelvkikkert.Models.PaymentInterval> PaymentInterval { get; set; }

        public DbSet<Soelvkikkert.Models.ProductPaymentInterval> ProductPaymentInterval { get; set; }

        public DbSet<Soelvkikkert.Models.SubscriberProduct> SubscriberProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<PaymentInterval>().ToTable("Payment Interval");
            modelBuilder.Entity<ProductPaymentInterval>().ToTable("ProductPaymentInterval");
            modelBuilder.Entity<ProductPaymentInterval>()
                .HasKey(p => new { p.PaymentIntervalID, p.ProductID });
            modelBuilder.Entity<SubscriberProduct>().ToTable("SubscriberProduct");
            modelBuilder.Entity<SubscriberProduct>()
                .HasKey(p => new { p.SubscriberID, p.ProductID });
        }
    }
}
