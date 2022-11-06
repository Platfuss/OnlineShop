using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IOrderDetailsService
{
    Task DeleteOrderDetailAsync(int id);
    Task<OrderDetail> GetOrderDetailAsync(int id);
    Task<OrderDetail> InsertOrderDetailAsync(OrderDetail model);
    Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail model);
}