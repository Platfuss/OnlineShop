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

    [HttpGet("{id}")]
    public async Task<OrderInfo> GetOrder(int id)
    {
        return await _ordersService.GetOrderAsync(id);
    }

    [HttpPost("order")]
    public async Task<Order> InsertOrder(OrderRequest request)
    {
        return await _ordersService.InsertOrderAsync(request);
    }
}
