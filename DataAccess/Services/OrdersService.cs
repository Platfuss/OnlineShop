using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Helpers;
using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class OrdersService : IOrdersService
{
    private readonly DataContext _db;
    private readonly ICartsService _cartsService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public OrdersService(DataContext db,
                         ICartsService cartsService,
                         IUserService userService,
                         IMapper mapper)
    {
        _db = db;
        _cartsService = cartsService;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<List<OrderInfo>> GetOrdersAsync()
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var customerOrders = new List<OrderInfo>();

        var orders = await _db.Orders
            .Include(o => o.InvoiceAddress)
            .Include(o => o.ShippingAddress)
            .Where(o => o.CustomerId == customerId)
            .OrderByDescending(o => o.CreationDate)
            .ToListAsync();

        foreach (var order in orders)
        {
            var orderedItems = await _db.OrderDetails
                .Where(od => od.OrderId == order.Id)
                .Include(od => od.Item)
                .Select(od => _mapper.Map<Item, BoughtItem>(od.Item))
                .AsNoTracking()
                .ToListAsync();

            var itemAmounts = await _db.OrderDetails
                .Where(od => od.OrderId == order.Id)
                .ToDictionaryAsync(od => od.ItemId, od => od.Amount);

            var totalPrice = 0M;
            foreach (var item in orderedItems)
            {
                item.Amount = itemAmounts[item.Id];
                totalPrice += item.Amount * item.Price;
            }

            var orderInfo = _mapper.Map<Order, OrderInfo>(order);
            orderInfo.OrderedItems = orderedItems;
            orderInfo.TotalPrice = totalPrice;

            customerOrders.Add(orderInfo);
        }

        return customerOrders;
    }

    public async Task<Order> InsertOrderAsync(OrderRequest request)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var isCartValid = (await _cartsService.ValidateAmountOfItemsAsync())
            .Count == 0;
        if (!isCartValid)
        {
            return null;
        }

        var orderModel = _mapper.Map<OrderRequest, Order>(request);
        orderModel.CustomerId = customerId;

        _db.Add(orderModel);
        await _db.SaveChangesAsync();
        var orderId = orderModel.Id;

        var cartEntries = await _db.Carts
            .Include(c => c.Item)
            .Where(c => c.CustomerId == customerId)
            .ToListAsync();

        foreach (var cartEntry in cartEntries)
        {
            cartEntry.Item.Amount -= cartEntry.Amount;
            var orderDetail = new OrderDetail() { OrderId = orderId, Amount = cartEntry.Amount, ItemId = cartEntry.ItemId };
            _db.OrderDetails.Add(orderDetail);
            _db.Remove(cartEntry);
        }

        await _db.SaveChangesAsync();

        return orderModel;
    }

    public async Task<Order> UpdateOrderAsync(Order model)
    {
        _db.Orders.Update(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var result = await _db.Orders.FindAsync(id);
        _db.Orders.Remove(result);
        await _db.SaveChangesAsync();
    }
}
