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
    public class CartsService : ICartsService
    {
        private readonly IDatabase _db;

        public CartsService(IDatabase db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CartModel>> GetUserCart(int customerId) =>
            await _db.ExecuteProcedure<CartModel, dynamic>("dbo.sp_Carts_GetUserCart", new { CustomerId = customerId });

        public async Task<CartModel> InsertIntoCart(CartModel model)
        {
            var results = await _db.ExecuteProcedure<CartModel, CartModel>("dbo.sp_Carts_Insert", model);
            return results.FirstOrDefault();
        }

        public async Task<CartModel> UpdateCart(CartModel model)
        {
            var results = await _db.ExecuteProcedure<CartModel, CartModel>("dbo.sp_Carts_Update", model);
            return results.FirstOrDefault();
        }

        public Task DeleteFromCart(int customerId, int itemId) =>
            _db.ExecuteProcedure("dbo.sp_Carts_Delete", new { CustomerId = customerId, ItemId = itemId });

    }
}
