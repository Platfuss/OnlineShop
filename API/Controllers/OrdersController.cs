using DataAccess.Services;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("GetOrder/{id}")]
        public async Task<OrderModel> GetOrder(int id)
        {
            return await _ordersService.GetOrder(id);
        }

        [HttpPost("InsertOrder")]
        public async Task InsertOrder(OrderModel model)
        {
            await _ordersService.InsertOrder(model);
        }

        [HttpPatch("UpdateOrder")]
        public async Task UpdateOrder(OrderModel model)
        {
            await _ordersService.UpdateOrder(model);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task DeleteOrder(int id)
        {
            await _ordersService.DeleteOrder(id);
        }
    }
}
