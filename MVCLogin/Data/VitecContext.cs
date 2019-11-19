using Microsoft.EntityFrameworkCore;
using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLogin.Data
{
    public class VitecContext : DbContext
    {
        public VitecContext(DbContextOptions<VitecContext> options)
            : base(options)
        {
        }

        public DbSet<MVCLogin.Models.Product> Product { get; set; }
        public DbSet<MVCLogin.Models.Subscriber> Subscriber { get; set; }
        public DbSet<MVCLogin.Models.Employee> Employee { get; set; }
        public DbSet<MVCLogin.Models.ProductPaymentInterval> ProductPaymentInterval { get; set; }
        public DbSet<MVCLogin.Models.PaymentInterval> PaymentInterval { get; set; }
        public DbSet<MVCLogin.Models.SubscriberProduct> SubscriberProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>()
                 .Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");
            modelBuilder.Entity<Subscriber>()
                 .Property(p => p.RowVersion).IsConcurrencyToken();
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>()
                 .Property(p => p.RowVersion).IsConcurrencyToken();
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