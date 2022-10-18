using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface ICartsService
    {
        Task DeleteFromCart(int userId, int itemId);
        Task<IEnumerable<CartModel>> GetUserCart(int id);
        Task<CartModel> InsertIntoCart(CartModel model);
        Task<CartModel> UpdateCart(CartModel model);
    }
}