using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;

namespace DataAccess.Services;

public class OrdersService : IOrdersService
{
    private readonly DataContext _db;

    public OrdersService(DataContext db)
    {
        _db = db;
    }

    public async Task<Order> GetOrderAsync(int id)
    {
        var result = await _db.Orders.FindAsync(id);
        return result;
    }

    public async Task<Order> InsertOrderAsync(Order model)
    {
        _db.Orders.Add(model);
        await _db.SaveChangesAsync();

        return model;
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
