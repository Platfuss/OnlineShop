using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly DataContext _db;

        public OrdersService(DataContext db)
        {
            _db = db;
        }

        public async Task<Order> GetOrder(int id)
        {
            var result = await _db.Orders.FindAsync(id);
            return result;
        }

        public async Task<Order> InsertOrder(Order model)
        {
            _db.Orders.Add(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<Order> UpdateOrder(Order model)
        {
            _db.Orders.Update(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task DeleteOrder(int id)
        {
            var result = await _db.Orders.FindAsync(id);
            _db.Orders.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}
