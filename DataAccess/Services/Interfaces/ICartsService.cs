using DataAccess.Models.Dto;

namespace DataAccess.Services.Interfaces;

public interface ICartsService
{
    Task DeleteFromCartAsync(int itemId);
    Task<IEnumerable<CartResponse>> GetUserCartAsync();
    Task<bool> AddToCartAsync(CartRequest request);
    Task<bool> UpdateCartAsync(CartRequest request);
    Task<List<string>> ValidateAmountOfItemsAsync();
}