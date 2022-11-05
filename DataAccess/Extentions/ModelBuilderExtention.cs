using DataAccess.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extentions;

public static class ModelBuilderExtention
{
    public static void Configure(this ModelBuilder builder)
    {
        var customers = builder.Entity<Customer>();
        customers.HasOne(c => c.DefaultInvoiceAddress).WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
        customers.HasOne(c => c.DefaultShippingAddress).WithOne().IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        var orders = builder.Entity<Order>();
        orders.HasOne(o => o.InvoiceAddress).WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
        orders.HasOne(o => o.ShippingAddress).WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
    }

    public static void SeedData(this ModelBuilder builder)
    {
        builder.Entity<Item>()
            .HasData(
                new Item()
                {
                    Id = 1,
                    Name = "Ciasto",
                    Description = "Coś do jedzenia",
                    Price = 3.5M,
                    Amount = 100,
                    Category = "Żywność",
                    AddedToShop = DateTime.Parse("2022-10-23 08:24:10")
                },
                new Item()
                {
                    Id = 2,
                    Name = "Twilight Imperium",
                    Description = "Spoko giera",
                    Price = 1000M,
                    Amount = 100,
                    Category = "Rozrywka",
                    AddedToShop = DateTime.Now
                },
                new Item()
                {
                    Id = 3,
                    Name = "Zwierzaczki",
                    Description = "Nie na sprzedaż!",
                    Price = 999999M,
                    Amount = 2,
                    Category = "Zoologia",
                    AddedToShop = DateTime.Parse("2015 - 07 - 01 12:15:50")
                },
                new Item()
                {
                    Id = 4,
                    Name = "Muzyka",
                    Description = "Piosenki piosenkarki",
                    Price = 65M,
                    Amount = 5000,
                    Category = "Rozrywka",
                    AddedToShop = DateTime.Parse("2022 - 11 - 05 10:15:07")
                }
           );

        builder.Entity<Address>()
            .HasData(
                new Address() { Id = 1, City = "Wrocław", Street = "Legnicka", Number = "156", SubNumber = null, PostalCode = "50-123", },
                new Address() { Id = 2, City = "Wrocław", Street = "Górnickiego", Number = "22", SubNumber = "37", PostalCode = "52-456", },
                new Address() { Id = 3, City = "Sokołów Młp.", Street = "Rzeszowska", Number = "44", SubNumber = null, PostalCode = "36-050", },
                new Address() { Id = 4, City = "Rzeszów", Street = "Architektów", Number = "123", SubNumber = null, PostalCode = "37-167", }
            );
        //builder.Entity<Customer>()
        //    .HasData(
        //        new Customer() { Name = "Eleonora", Surname = "Zadecka", Email = "eleonora.zadecka@o2.pl", Addresses = new List<Address>() { new Address { Id = 5 } } }
        //    );

        //builder.Entity<Cart>()
        //    .HasData(
        //        new Cart() { Id = 1, CustomerId = 3, ItemId = 2, Amount = 5},
        //        new Cart() { Id = 2, CustomerId = 3, ItemId = 3, Amount = 20}
        //    );
    }
}
