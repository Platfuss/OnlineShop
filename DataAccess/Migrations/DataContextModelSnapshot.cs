﻿// <auto-generated />
using System;
using DataAccess.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Models.Database.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Wrocław",
                            Number = "156",
                            PostalCode = "50-123",
                            Street = "Legnicka"
                        },
                        new
                        {
                            Id = 2,
                            City = "Wrocław",
                            Number = "22",
                            PostalCode = "52-456",
                            Street = "Górnickiego",
                            SubNumber = "37"
                        },
                        new
                        {
                            Id = 3,
                            City = "Sokołów Młp.",
                            Number = "44",
                            PostalCode = "36-050",
                            Street = "Rzeszowska"
                        },
                        new
                        {
                            Id = 4,
                            City = "Rzeszów",
                            Number = "123",
                            PostalCode = "37-167",
                            Street = "Architektów"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Database.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ItemId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DataAccess.Models.Database.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DefaultInvoiceAddressId")
                        .HasColumnType("int");

                    b.Property<int?>("DefaultShippingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DefaultInvoiceAddressId")
                        .IsUnique();

                    b.HasIndex("DefaultShippingAddressId")
                        .IsUnique()
                        .HasFilter("[DefaultShippingAddressId] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataAccess.Models.Database.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddedToShop")
                        .HasColumnType("datetime2");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedToShop = new DateTime(2022, 10, 23, 8, 24, 10, 0, DateTimeKind.Unspecified),
                            Amount = 100,
                            Category = "Żywność",
                            Description = "Coś do jedzenia",
                            Name = "Ciasto",
                            Price = 3.5m
                        },
                        new
                        {
                            Id = 2,
                            AddedToShop = new DateTime(2022, 11, 5, 15, 24, 46, 879, DateTimeKind.Local).AddTicks(5688),
                            Amount = 100,
                            Category = "Rozrywka",
                            Description = "Spoko giera",
                            Name = "Twilight Imperium",
                            Price = 1000m
                        },
                        new
                        {
                            Id = 3,
                            AddedToShop = new DateTime(2015, 7, 1, 12, 15, 50, 0, DateTimeKind.Unspecified),
                            Amount = 2,
                            Category = "Zoologia",
                            Description = "Nie na sprzedaż!",
                            Name = "Zwierzaczki",
                            Price = 999999m
                        },
                        new
                        {
                            Id = 4,
                            AddedToShop = new DateTime(2022, 11, 5, 10, 15, 7, 0, DateTimeKind.Unspecified),
                            Amount = 5000,
                            Category = "Rozrywka",
                            Description = "Piosenki piosenkarki",
                            Name = "Muzyka",
                            Price = 65m
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Database.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceAddressId")
                        .HasColumnType("int");

                    b.Property<string>("ShipmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InvoiceAddressId")
                        .IsUnique();

                    b.HasIndex("ShippingAddressId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Models.Database.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DataAccess.Models.Database.Cart", b =>
                {
                    b.HasOne("DataAccess.Models.Database.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Database.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataAccess.Models.Database.Customer", b =>
                {
                    b.HasOne("DataAccess.Models.Database.Address", "DefaultInvoiceAddress")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Database.Customer", "DefaultInvoiceAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Database.Address", "DefaultShippingAddress")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Database.Customer", "DefaultShippingAddressId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("DefaultInvoiceAddress");

                    b.Navigation("DefaultShippingAddress");
                });

            modelBuilder.Entity("DataAccess.Models.Database.Order", b =>
                {
                    b.HasOne("DataAccess.Models.Database.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Database.Address", "InvoiceAddress")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Database.Order", "InvoiceAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Database.Address", "ShippingAddress")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Database.Order", "ShippingAddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InvoiceAddress");

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("DataAccess.Models.Database.OrderDetail", b =>
                {
                    b.HasOne("DataAccess.Models.Database.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Database.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
