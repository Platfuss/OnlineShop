using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Converters;
using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class CartsService : ICartsService
    {
        private readonly IDatabase _db;
        private readonly IFileService _fileService;

        public CartsService(IDatabase db, IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public async Task<IEnumerable<CartDto>> GetUserCart(int customerId)
        {
            var userCart = (await _db.ExecuteProcedure<CartModel, dynamic>
                ("dbo.sp_Carts_GetUserCart", new { CustomerId = customerId }))
                .ToList();
            var output = new List<CartDto>();
            foreach(var item in userCart)
            {
                var image = (await _fileService.Read(item.Id.ToString(), true))
                    .FirstOrDefault();
                output.Add(CartConverter.ModelToDto(item, image));
            }
            return output;
        }

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
