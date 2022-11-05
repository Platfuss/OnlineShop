using DataAccess.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task<OrderDetail> GetOrderDetail(int id)
    {
        return await _orderDetailsService.GetOrderDetail(id);
    }

    [HttpPost("InsertOrderDetail")]
    public async Task<OrderDetail> InsertOrderDetail(OrderDetail model)
    {
        return await _orderDetailsService.InsertOrderDetail(model);
    }

    [HttpPatch("UpdateOrderDetail")]
    public async Task<OrderDetail> UpdateOrderDetail(OrderDetail model)
    {
        return await _orderDetailsService.UpdateOrderDetail(model);
    }

    [HttpDelete("DeleteOrderDetail/{id}")]
    public async Task DeleteOrderDetail(int id)
    {
        await _orderDetailsService.DeleteOrderDetail(id);
    }
}
