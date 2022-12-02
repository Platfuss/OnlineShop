using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ICartsService _cartsService;

    public CartsController(ICartsService cartsService) => _cartsService = cartsService;

    [HttpGet("get")]
    public async Task<IEnumerable<CartResponse>> GetUserCart() => await _cartsService.GetUserCartAsync();

    [HttpGet("total-price")]
    public async Task<decimal> GetTotalPrice()
    {
        return await _cartsService.GetCartTotalPriceAsync();
    }

    [HttpPost("add-item")]
    public async Task<bool> AddItemToCart(CartRequest request)
    {
        return await _cartsService.AddToCartAsync(request);
    }

    [HttpPatch("update")]
    public async Task<bool> UpdateCart(CartRequest request)
    {
        return await _cartsService.UpdateCartAsync(request);
    }

    [HttpPost("validate")]
    public async Task<CartValidationResponse> ValidateAmountOfItems(List<CartRequest> cartRequests)
    {
        return await _cartsService.ValidateAmountOfItemsAsync(cartRequests);
    }

    [HttpDelete("{itemId}")]
    public Task<bool> DeleteItemFromCart(int itemId) =>
        _cartsService.DeleteFromCartAsync(itemId);
}