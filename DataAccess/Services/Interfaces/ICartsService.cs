using DataAccess.Models.Database;
using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface ICartsService
{
    Task DeleteFromCart(int userId, int itemId);
    Task<IEnumerable<CartDto>> GetUserCart(int id);
    Task<Cart> InsertIntoCart(Cart model);
    Task<Cart> UpdateCart(Cart model);
}