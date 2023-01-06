using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models;
using DataAccess.Models.Database;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DataAccessTests;

public class CustomersServiceTests
{
    private readonly CustomersService _customersService;
    private readonly DataContext _dataContext;
    private readonly Mock<IUserService> _userService = new();
    private readonly Mapper _autoMapper = new(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));

    public CustomersServiceTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        _dataContext = new DataContext(options);
        _dataContext.Customers.AddRange(GetFakeCustomers());
        _dataContext.SaveChanges();
        _customersService = new CustomersService(_dataContext, _userService.Object, _autoMapper);
    }

    [Fact]
    public async void GetCusomerAsync_CustomerExist_ShouldReturnInfo()
    {
        var dbCustomer = _dataContext.Customers.Where(x => x.Id == 1).Single();
        _userService.Setup(x => x.GetCustomerIdAsync()).ReturnsAsync(1);

        var customer = await _customersService.GetCustomerAsync();

        Assert.Equal(customer.Name, dbCustomer.Name);
        Assert.Equal(customer.Surname, dbCustomer.Surname);
    }

    [Fact]
    public async void GetCusomerAsync_CustomerDoesNotExist_ShouldReturnNull()
    {
        _userService.Setup(x => x.GetCustomerIdAsync()).ReturnsAsync(2);

        var customer = await _customersService.GetCustomerAsync();

        Assert.Null(customer);
    }



    private static List<Customer> GetFakeCustomers()
    {
        return new List<Customer>() 
            {
                new Customer() { Id = 1, Name = "Michau", Surname = "Stanislau" }
            };
    }
}