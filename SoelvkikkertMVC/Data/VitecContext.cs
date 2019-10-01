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
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<PaymentInterval>().ToTable("PaymentInterval");
            modelBuilder.Entity<ProductPaymentInterval>().ToTable("ProductPaymentInterval");
            modelBuilder.Entity<ProductPaymentInterval>()
                .HasKey(p => new { p.PaymentIntervalID, p.ProductID });
            modelBuilder.Entity<SubscriberProduct>().ToTable("SubscriberProduct");
            modelBuilder.Entity<SubscriberProduct>()
                .HasKey(p => new { p.SubscriberID, p.ProductID });
        }
    }
}
