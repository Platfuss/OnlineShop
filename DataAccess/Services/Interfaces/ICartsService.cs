using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;

namespace DataAccess.Services.Interfaces;

public interface ICartsService
{
    Task<bool> DeleteFromCartAsync(int itemId);
    Task<IEnumerable<CartResponse>> GetUserCartAsync();
    Task<bool> AddToCartAsync(CartRequest request);
    Task<bool> UpdateCartAsync(CartRequest request);
    Task<decimal> GetCartTotalPriceAsync();
    Task<CartValidationResponse> ValidateAmountOfItemsAsync(List<CartRequest> cartRequest);
    Task<List<string>> ValidateAmountOfItemsAsync();
}