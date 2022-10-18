using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("GetOrderDetail/{id}")]
        public async Task<OrderDetailModel> GetOrderDetail(int id)
        {
            return await _orderDetailsService.GetOrderDetail(id);
        }

        [HttpPost("InsertOrderDetail")]
        public async Task<OrderDetailModel> InsertOrderDetail(OrderDetailModel model)
        {
            return await _orderDetailsService.InsertOrderDetail(model);
        }

        [HttpPatch("UpdateOrderDetail")]
        public async Task<OrderDetailModel> UpdateOrderDetail(OrderDetailModel model)
        {
            return await _orderDetailsService.UpdateOrderDetail(model);
        }

        [HttpDelete("DeleteOrderDetail/{id}")]
        public async Task DeleteOrderDetail(int id)
        {
            await _orderDetailsService.DeleteOrderDetail(id);
        }
    }
}
