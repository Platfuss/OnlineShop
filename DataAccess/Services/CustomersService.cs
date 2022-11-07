using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class CustomersService : ICustomersService
{
    private readonly DataContext _db;
    private readonly IUserService _userService;

    public CustomersService(DataContext db, IUserService userService)
    {
        _db = db;
        _userService = userService;
    }

    public async Task<Customer> GetCustomerAsync()
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var result = await _db.Customers.FindAsync(customerId);
        return result;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer model)
    {
        _db.Customers.Update(model);
        await _db.SaveChangesAsync();

        return model;
    }
}
