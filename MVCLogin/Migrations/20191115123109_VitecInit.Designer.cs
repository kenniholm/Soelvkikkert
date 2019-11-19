﻿// <auto-generated />
using System;
using MVCLogin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCLogin.Migrations
{
    [DbContext(typeof(VitecContext))]
    [Migration("20191115123109_VitecInit")]
    partial class VitecInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCLogin.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Administrator")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("MVCLogin.Models.PaymentInterval", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("PaymentInterval");
                });

            modelBuilder.Entity("MVCLogin.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int?>("SubscriberID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SubscriberID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MVCLogin.Models.ProductPaymentInterval", b =>
                {
                    b.Property<int>("PaymentIntervalID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("PaymentIntervalID", "ProductID");

                    b.ToTable("ProductPaymentInterval");
                });

            modelBuilder.Entity("MVCLogin.Models.Subscriber", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("MVCLogin.Models.SubscriberProduct", b =>
                {
                    b.Property<int>("SubscriberID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentIntervalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscriptionStart")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriberID", "ProductID");

                    b.HasIndex("PaymentIntervalID");

                    b.ToTable("SubscriberProduct");
                });

            modelBuilder.Entity("MVCLogin.Models.Product", b =>
                {
                    b.HasOne("MVCLogin.Models.Subscriber", null)
                        .WithMany("products")
                        .HasForeignKey("SubscriberID");
                });

            modelBuilder.Entity("MVCLogin.Models.SubscriberProduct", b =>
                {
                    b.HasOne("MVCLogin.Models.PaymentInterval", "SelectedPaymentInterval")
                        .WithMany()
                        .HasForeignKey("PaymentIntervalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}