﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubscriberAPI.Models;

namespace SubscriberAPI.Migrations
{
    [DbContext(typeof(SubscriberAPIContext))]
    [Migration("20191105104858_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SubscriberAPI.Models.SubscriberProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PaymentIntervalID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("SubscriberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscribtionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscribtionStart")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("SubscriberProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
