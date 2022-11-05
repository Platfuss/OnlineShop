using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class CartsService : ICartsService
{
    private readonly DataContext _db;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public CartsService(DataContext db, IFileService fileService, IMapper mapper)
    {
        _db = db;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CartDto>> GetUserCart(int customerId)
    {
        var userCart = await _db.Carts.Where(cart => cart.CustomerId == customerId).ToListAsync();
        var output = new List<CartDto>();
        foreach (var item in userCart)
        {
            var image = (await _fileService.Read(item.Id.ToString(), true))
                .FirstOrDefault();
            var cartEntry = _mapper.Map<Cart, CartDto>(item, opt => opt.AfterMap((src, dest) => dest.Image = image));
            output.Add(cartEntry);
        }
        return output;
    }

    public async Task<Cart> InsertIntoCart(Cart model)
    {
        _db.Carts.Add(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task<Cart> UpdateCart(Cart model)
    {
        _db.Carts.Update(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async Task DeleteFromCart(int customerId, int itemId)
    {
        var cartEntry = _db.Carts.Where(x => x.CustomerId == customerId && x.ItemId == itemId).FirstOrDefault();
        _db.Carts.Remove(cartEntry);
        await _db.SaveChangesAsync();
    }
}
