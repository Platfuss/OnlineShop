using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IDatabase _db;

        public OrderDetailsService(IDatabase db)
        {
            _db = db;
        }

        public async Task<OrderDetail> GetOrderDetail(int id)
        {
            var results = await _db.ExecuteProcedure<OrderDetail, dynamic>("dbo.sp_OrderDetails_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<OrderDetail> InsertOrderDetail(OrderDetail model)
        {
            var results = await _db.ExecuteProcedure<OrderDetail, OrderDetail>("dbo.sp_OrderDetails_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail model)
        {
            var results = await _db.ExecuteProcedure<OrderDetail, OrderDetail>("dbo.sp_OrderDetails_Update", model);
            return results.FirstOrDefault();
        }
            
        public Task DeleteOrderDetail(int id) =>
            _db.ExecuteProcedure("dbo.sp_OrderDetails_Delete", new { Id = id });
    }
}
