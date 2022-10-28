using DataAccess.Models.Dto;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartsService _cartsService;

        public CartController(ICartsService cartsService) => _cartsService = cartsService;

        [HttpGet("GetUserCart/id")]
        public async Task<IEnumerable<CartDto>> GetUserCart(int id) => await _cartsService.GetUserCart(id);

        // TODO: Validate if amount isn't greater that amount in stock
        [HttpPost("InsertIntoCart")]
        public async Task<CartModel> InsertItemIntoCart(CartModel model)
        {
            return await _cartsService.InsertIntoCart(model);
        }

        [HttpPatch("UpdateCart")]
        public async Task<CartModel> UpdateCart(CartModel model)
        {
            return await _cartsService.UpdateCart(model);
        }

        [HttpDelete("DeleteItemFromCart/{customerId}/{itemId}")]
        public Task DeleteItemFromCart(int customerId, int itemId) =>
            _cartsService.DeleteFromCart(customerId, itemId);

    }
}
