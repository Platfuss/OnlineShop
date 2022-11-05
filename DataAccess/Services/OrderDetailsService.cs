using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly DataContext _db;

        public OrderDetailsService(DataContext db)
        {
            _db = db;
        }

        public async Task<OrderDetail> GetOrderDetail(int id)
        {
            var result = await _db.OrderDetails.FindAsync(id);
            return result;
        }

        public async Task<OrderDetail> InsertOrderDetail(OrderDetail model)
        {
            _db.OrderDetails.Add(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail model)
        {
            _db.OrderDetails.Update(model);
            await _db.SaveChangesAsync();

            return model;
        }
            
        public async Task DeleteOrderDetail(int id)
        {
            var result = await _db.OrderDetails.FindAsync(id);
            _db.OrderDetails.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}
