using DataAccess.Services.Interfaces;
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
        public async Task<IEnumerable<CartModel>> GetUserCart(int id)
        {
            return await _cartsService.GetUserCart(id);
        }

        // TODO: Validate if amount isn't greater that amount in stock
        [HttpPost("InsertIntoCart")]
        public void InsertItemIntoCart(CartModel model) =>
            _cartsService.InsertIntoCart(model);

        [HttpPatch("UpdateCart")]
        public void UpdateCart(CartModel model) =>
            _cartsService.UpdateCart(model);

        [HttpDelete("DeleteItemFromCart/{customerId}/{itemId}")]
        public void DeleteItemFromCart(int customerId, int itemId) =>
            _cartsService.DeleteFromCart(customerId, itemId);

    }
}
