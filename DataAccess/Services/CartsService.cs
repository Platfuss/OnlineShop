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

        public async Task<CartModel> GetUserCart(int id)
        {
            var results = await _db.LoadData<CartModel, dynamic>("dbo.sp_Cart_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertIntoCart(CartModel model) =>
            _db.SaveData("dbo.sp_Cart_Insert", model);

        public Task DeleteFromCart(int customerId, int itemId) =>
            _db.SaveData("dbo.sp_Cart_Delete", new { CustomerId = customerId, ItemId = itemId });
    }
}
