using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Services.Interfaces;

namespace DataAccess.Services;

public class AddressService : IAddressService
{
    private readonly DataContext _db;

    public AddressService(DataContext db)
    {
        _db = db;
    }

    public async Task<Address> GetAddressAsync(int id)
    {
        var address = await _db.Addresses.FindAsync(id);
        return address;
    }

    public async Task<Address> UpdateAddressAsync(Address model)
    {
        _db.Addresses.Update(model);
        await _db.SaveChangesAsync();

        return model;
    }
}
