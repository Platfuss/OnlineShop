using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;

namespace DataAccess.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly DataContext _db;

    public OrderDetailsService(DataContext db)
    {
        _db = db;
    }

    public async Task<OrderDetail> GetOrderDetailAsync(int id)
    {
        var result = await _db.OrderDetails.FindAsync(id);
        return result;
    }

    public async Task<OrderDetail> InsertOrderDetailAsync(OrderDetail model)
    {
        _db.OrderDetails.Add(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail model)
    {
        _db.OrderDetails.Update(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task DeleteOrderDetailAsync(int id)
    {
        var result = await _db.OrderDetails.FindAsync(id);
        _db.OrderDetails.Remove(result);
        await _db.SaveChangesAsync();
    }
}
