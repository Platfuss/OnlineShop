using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet("all")]
    public async Task<List<OrderInfo>> GetOrders()
    {
        return await _ordersService.GetOrdersAsync();
    }

    [HttpPost("create")]
    public async Task<Order> InsertOrder(OrderRequest request)
    {
        return await _ordersService.InsertOrderAsync(request);
    }
}
