using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class CustomersService : ICustomersService
{
    private readonly DataContext _db;

    public CustomersService(DataContext db)
    {
        _db = db;
    }

    public async Task<Customer> GetCustomerAsync(int id)
    {
        var result = await _db.Customers.FindAsync(id);
        return result;
    }
    public async Task<IEnumerable<Customer>> GetCustomersAllAsync()
    {
        var result = await _db.Customers.ToListAsync();
        return result;
    }

    public async Task<Customer> InsertCustomerAsync(Customer model)
    {
        _db.Customers.Add(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer model)
    {
        _db.Customers.Update(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var result = await _db.Customers.FindAsync(id);
        _db.Customers.Remove(result);
        await _db.SaveChangesAsync();
    }
}
