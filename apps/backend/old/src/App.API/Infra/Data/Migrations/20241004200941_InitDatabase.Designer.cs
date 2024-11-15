﻿// <auto-generated />
using System;
using FwksLabs.AppService.Core.Resources.Common.Models;
using FwksLabs.AppService.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FwksLabs.AppService.Infra.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241004200941_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FwksLabs.AppService.Core.Resources.Customers.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<AddressModel>("Address")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<NameModel>("Name")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<PhoneNumberModel>("Phone")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Customers");

                    b.HasIndex("UniqueId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_Customers");

                    b.ToTable("Customers", "App");
                });

            modelBuilder.Entity("FwksLabs.AppService.Core.Resources.Orders.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("PK_Orders");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UniqueId")
                        .IsUnique()
                        .HasDatabaseName("IX_UK_Orders");

                    b.ToTable("Orders", "App");
                });

            modelBuilder.Entity("FwksLabs.AppService.Core.Resources.Orders.OrderEntity", b =>
                {
                    b.HasOne("FwksLabs.AppService.Core.Resources.Customers.CustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FwksLabs.AppService.Core.Resources.Customers.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
