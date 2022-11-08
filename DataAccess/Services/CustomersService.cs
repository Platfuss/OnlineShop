using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Services.Interfaces;

namespace DataAccess.Services;

public class CustomersService : ICustomersService
{
    private readonly DataContext _db;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CustomersService(DataContext db, IUserService userService, IMapper mapper)
    {
        _db = db;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<CustomerBasicInfo> GetCustomerAsync()
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var customer = await _db.Customers.FindAsync(customerId);
        var simpleCustomer = _mapper.Map<CustomerBasicInfo>(customer);
        return simpleCustomer;
    }

    public async Task<Customer> UpdateCustomerAsync(CustomerBasicInfo customerNewInfo)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var customer = await _db.Customers.FindAsync(customerId);

        _mapper.Map(customerNewInfo, customer);
        await _db.SaveChangesAsync();

        return customer;
    }
}
