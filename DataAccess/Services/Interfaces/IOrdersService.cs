using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;

namespace DataAccess.Services.Interfaces;

public interface IOrdersService
{
    Task<List<OrderInfo>> GetOrdersAsync();
    Task<Order> InsertOrderAsync(OrderRequest request);
}