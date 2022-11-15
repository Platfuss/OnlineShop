using DataAccess.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extentions;

public static class ModelBuilderExtention
{
    public static void Configure(this ModelBuilder builder)
    {
        var customerAddress = builder.Entity<CustomerAddress>();
        customerAddress.HasKey(ca => new { ca.AddressId, ca.CustomerId });
        customerAddress.HasOne(ca => ca.Address).WithMany(a => a.CustomerAddress).HasForeignKey(ca => ca.AddressId);
        customerAddress.HasOne(ca => ca.Customer).WithMany(c => c.CustomerAddress).HasForeignKey(ca => ca.CustomerId);

        var orders = builder.Entity<Order>();
        orders.HasOne(o => o.InvoiceAddress).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        orders.HasOne(o => o.ShipingAddress).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);

        var orderDetails = builder.Entity<OrderDetail>();
        orderDetails.HasIndex(od => new { od.OrderId, od.ItemId }).IsUnique();

        var users = builder.Entity<User>();
        users.HasOne(u => u.Customer).WithOne(c => c.User).IsRequired();
        users.HasIndex(u => u.Email).IsUnique();

        var carts = builder.Entity<Cart>();
        carts.HasIndex(c => new { c.CustomerId, c.ItemId }).IsUnique();


        builder.Entity<Item>()
            .HasData(
                new Item() { Id = 1, Name = "Ciasto", Description = "Coś do jedzenia", Price = 3.5M, Amount = 0, Category = "Żywność", AddedToShop = DateTime.Parse("2022-10-23 08:24:10") },
                new Item() { Id = 2, Name = "Twilight Imperium", Description = "Spoko giera", Price = 1000M, Amount = 100, Category = "Rozrywka", AddedToShop = DateTime.Now, Recommended = true },
                new Item() { Id = 3, Name = "Zwierzaczki", Description = "Nie na sprzedaż!", Price = 999999M, Amount = 2, Category = "Zoologia", AddedToShop = DateTime.Parse("2015 - 07 - 01 12:15:50") },
                new Item() { Id = 4, Name = "Muzyka", Description = "Piosenki piosenkarki", Price = 65M, Amount = 5000, Category = "Rozrywka", AddedToShop = DateTime.Parse("2022 - 11 - 05 10:15:07") }
           );

        builder.Entity<Address>()
            .HasData(
                new Address() { Id = 1, City = "Wrocław", Street = "Legnicka", Number = "156", SubNumber = null, PostalCode = "50-123", },
                new Address() { Id = 2, City = "Wrocław", Street = "Górnickiego", Number = "22", SubNumber = "37", PostalCode = "52-456", },
                new Address() { Id = 3, City = "Sokołów Młp.", Street = "Rzeszowska", Number = "44", SubNumber = null, PostalCode = "36-050", },
                new Address() { Id = 4, City = "Rzeszów", Street = "Architektów", Number = "123", SubNumber = null, PostalCode = "37-167", }
            );

        builder.Entity<Customer>()
            .HasData(
                new Customer() { Id = 1, Name = "Michau", Surname = "Stanislau" },
                new Customer() { Id = 2, Name = "Władysław", Surname = "Włodecki" },
                new Customer() { Id = 3, Name = "Tomek", Surname = "Polok" },
                new Customer() { Id = 4, Name = "Aleksandra", Surname = "Schabowicka" }
            );

        customerAddress.HasData(
            new { AddressId = 1, CustomerId = 1 },
            new { AddressId = 1, CustomerId = 2 },
            new { AddressId = 2, CustomerId = 3 },
            new { AddressId = 3, CustomerId = 4 },
            new { AddressId = 4, CustomerId = 4 }
        );

        users.HasData(
                new User()
                {
                    Id = 1,
                    Email = "user@example.com",
                    PasswordHash = Convert.FromHexString("06ABE76258A3A95573FEEFAB8DBEDCFE0C8C8C446A998188543B3A64BDA5E85011F29E8DB00879DE6DCB6077D9F4002A01549414849A913DAABCF7E9D3529F44"),
                    PasswordSalt = Convert.FromHexString("EFDB8832074402985B10F01E1518636E411B475576F4C07257C7659D523034DA3286EBB8779CFB6B4B2E572D221FFD5BC863E34B6C6AB0C8340F5A4328CC789A61158BB8AF6FCC472DCAA02931F78E2E65CA73C379B157777966F359690FCDC4B834FFED1988EC78E98B39FF92B2AC9BCC84B53DECA107E4159237F7AC8C4F09"),
                    CustomerId = 1
                }
            );

        carts.HasData(
                new Cart() { Id = 1, CustomerId = 3, ItemId = 2, Amount = 5 },
                new Cart() { Id = 2, CustomerId = 3, ItemId = 3, Amount = 20 }
            );

        orders.HasData(
                new Order()
                {
                    Id = 1,
                    CreationDate = DateTime.Parse("2022-10-22 23:32:00"),
                    CustomerId = 1,
                    InvoiceAddressId = 1,
                    ShipingAddressId = 2,
                    ShipmentType = "Kurier",
                    Status = "Zatwierdzone"
                },
                new Order()
                {
                    Id = 2,
                    CreationDate = DateTime.Parse("2022-10-23 10:00:00"),
                    CustomerId = 2,
                    InvoiceAddressId = 1,
                    ShipingAddressId = 1,
                    ShipmentType = "InPost",
                    Status = "Wysłane"
                }
            );

        orderDetails.HasData(
                new OrderDetail() { Id = 1, OrderId = 1, ItemId = 1, Amount = 10 },
                new OrderDetail() { Id = 2, OrderId = 1, ItemId = 2, Amount = 1 },
                new OrderDetail() { Id = 3, OrderId = 1, ItemId = 3, Amount = 3 },
                new OrderDetail() { Id = 4, OrderId = 1, ItemId = 4, Amount = 1 },
                new OrderDetail() { Id = 5, OrderId = 2, ItemId = 1, Amount = 40 },
                new OrderDetail() { Id = 6, OrderId = 2, ItemId = 3, Amount = 20 },
                new OrderDetail() { Id = 7, OrderId = 2, ItemId = 4, Amount = 1 }
            );
    }
}
