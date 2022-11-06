using DataAccess.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task<Order> GetOrder(int id)
    {
        return await _ordersService.GetOrderAsync(id);
    }

    [HttpPost("InsertOrder")]
    public async Task<Order> InsertOrder(Order model)
    {
        return await _ordersService.InsertOrderAsync(model);
    }

    [HttpPatch("UpdateOrder")]
    public async Task<Order> UpdateOrder(Order model)
    {
        return await _ordersService.UpdateOrderAsync(model);
    }

    [HttpDelete("DeleteOrder/{id}")]
    public async Task DeleteOrder(int id)
    {
        await _ordersService.DeleteOrderAsync(id);
    }
}
