using DataAccess.Models.Database;

namespace DataAccess.Services.Interfaces;

public interface IOrdersService
{
    Task DeleteOrderAsync(int id);
    Task<Order> GetOrderAsync(int id);
    Task<Order> InsertOrderAsync(Order model);
    Task<Order> UpdateOrderAsync(Order model);
}