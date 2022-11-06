using DataAccess.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartsService _cartsService;

    public CartController(ICartsService cartsService) => _cartsService = cartsService;

    [HttpGet("GetUserCart")]
    public async Task<IEnumerable<CartResponse>> GetUserCart() => await _cartsService.GetUserCartAsync();

    [HttpPost("AddItemToCart")]
    public async Task<bool> AddItemToCart(CartRequest request)
    {
        return await _cartsService.AddToCartAsync(request);
    }

    [HttpPost("ValidateAmountOfItems")]
    public async Task<List<string>> ValidateAmountOfItems()
    {
        return await _cartsService.ValidateAmountOfItemsAsync();
    }

    [HttpPatch("UpdateCart")]
    public async Task<bool> UpdateCart(CartRequest request)
    {
        return await _cartsService.UpdateCartAsync(request);
    }

    [HttpDelete("DeleteItemFromCart/{itemId}")]
    public Task DeleteItemFromCart(int itemId) =>
        _cartsService.DeleteFromCartAsync(itemId);

}
