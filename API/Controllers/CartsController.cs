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

    [HttpPost("add-item")]
    public async Task<bool> AddItemToCart(CartRequest request)
    {
        return await _cartsService.AddToCartAsync(request);
    }

    [HttpPost("validate")]
    public async Task<List<string>> ValidateAmountOfItems()
    {
        return await _cartsService.ValidateAmountOfItemsAsync();
    }

    [HttpPatch("update")]
    public async Task<bool> UpdateCart(CartRequest request)
    {
        return await _cartsService.UpdateCartAsync(request);
    }

    [HttpDelete("{itemId}")]
    public Task DeleteItemFromCart(int itemId) =>
        _cartsService.DeleteFromCartAsync(itemId);

}
