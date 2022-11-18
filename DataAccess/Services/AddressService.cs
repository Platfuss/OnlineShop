using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class AddressService : IAddressService
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public AddressService(DataContext db, IMapper mapper, IUserService userService)
    {
        _db = db;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<Address> UpdateAddressAsync(Address request)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var addressId = request.Id;

        var usedInOrders = _db.Orders
            .Any(o => o.InvoiceAddressId == addressId
                || o.ShippingAddressId == addressId);

        Address output = null;
        if (usedInOrders)
        {
            output = request;
            output.Id = 0;
            _db.Addresses.Add(output);
            await _db.SaveChangesAsync();

            var currentAddress = await _db.CustomerAddress
                .Where(ca => ca.CustomerId == customerId
                    && ca.AddressId == addressId)
                .SingleAsync();

            _db.CustomerAddress.Remove(currentAddress);
            _db.CustomerAddress.Add(new CustomerAddress { CustomerId = customerId, AddressId = output.Id });

            await _db.SaveChangesAsync();
        }
        else
        {
            output = await _db.CustomerAddress
                .Where(ca => ca.CustomerId == customerId
                    && ca.AddressId == addressId)
                .Select(ca => ca.Address)
                .FirstOrDefaultAsync();

            _mapper.Map(request, output);
            await _db.SaveChangesAsync();
        }

        return output;
    }

    public async Task<bool> DeleteAddressAsync(int addressId)
    {
        var customerId = await _userService.GetCustomerIdAsync();

        var usedInOrders = _db.Orders
            .Any(o => o.InvoiceAddressId == addressId
                || o.ShippingAddressId == addressId);

        if (usedInOrders)
        {
            var addressToForget = await _db.CustomerAddress
                 .Where(ca => ca.CustomerId == customerId
                     && ca.AddressId == addressId)
                 .FirstOrDefaultAsync();

            _db.CustomerAddress.Remove(addressToForget);
        }
        else
        {
            var addressToDelete = await _db.Addresses
                .Where(a => a.Id == addressId)
                .FirstOrDefaultAsync();

            _db.Addresses.Remove(addressToDelete);
        }

        var rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected == 1;
    }

    public async Task<Address> AddAddressAsync(AddressRequest request)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var output = _mapper.Map<Address>(request);
        _db.Addresses.Add(output);
        await _db.SaveChangesAsync();
        _db.CustomerAddress.Add(new CustomerAddress() { AddressId = output.Id, CustomerId = customerId });
        await _db.SaveChangesAsync();

        return output;
    }

    public async Task<List<Address>> GetAddressesAsync()
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var userAddresses = await _db.CustomerAddress
            .Where(ca => ca.CustomerId == customerId)
            .Include(ca => ca.Address)
            .Select(ca => ca.Address)
            .ToListAsync();

        return userAddresses;
    }

    public async Task<Address> GetAddressesAsync(int id)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var userAddresses = await _db.CustomerAddress
            .Where(ca => ca.CustomerId == customerId)
            .Include(ca => ca.Address)
            .Where(ca => ca.AddressId == id)
            .Select(ca => ca.Address)
            .FirstOrDefaultAsync();

        return userAddresses;
    }
}
