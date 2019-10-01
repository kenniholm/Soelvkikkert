using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoelvkikkertMVC.Models;

namespace SoelvkikkertMVC.Models
{
    public class VitecContext : DbContext
    {
        public VitecContext(DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<SoelvkikkertMVC.Models.Product> Product { get; set; }
        public DbSet<SoelvkikkertMVC.Models.Subscriber> Subscriber { get; set; }
        public DbSet<SoelvkikkertMVC.Models.ProductPaymentInterval> ProductPaymentInterval { get; set; }
        public DbSet<SoelvkikkertMVC.Models.PaymentInterval> PaymentInterval { get; set; }
        public DbSet<SoelvkikkertMVC.Models.SubscriberProduct> SubscriberProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>()
                 .Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<Subscriber>()
                 .Property(p => p.RowVersion).IsConcurrencyToken();
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
