using DataAccess.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccess.DatabaseAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
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
        }
    }
}