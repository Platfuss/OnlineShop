using DataAccess.Models;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces
{
    public interface ICartsService
    {
        Task DeleteFromCart(int userId, int itemId);
        Task<IEnumerable<CartDto>> GetUserCart(int id);
        Task<CartModel> InsertIntoCart(CartModel model);
        Task<CartModel> UpdateCart(CartModel model);
    }
}