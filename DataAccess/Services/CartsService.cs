using AutoMapper;
using DataAccess.DatabaseAccess;
using DataAccess.Models.Database;
using DataAccess.Models.Dto.Requests;
using DataAccess.Models.Dto.Responses;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services;

public class CartsService : ICartsService
{
    private readonly DataContext _db;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public CartsService(DataContext db, IFileService fileService, IMapper mapper, IUserService userService)
    {
        _db = db;
        _fileService = fileService;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<IEnumerable<CartResponse>> GetUserCartAsync()
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var userCart = await _db.Carts.Where(cart => cart.CustomerId == customerId).Include(c => c.Item).ToListAsync();
        var output = new List<CartResponse>();
        foreach (var item in userCart)
        {
            var image = (await _fileService.ReadAsync(item.ItemId.ToString(), onlyFirst: true))
                .FirstOrDefault();
            var cartEntry = _mapper.Map<Cart, CartResponse>(item, opt => opt.AfterMap((src, dest) => dest.Image = image));
            output.Add(cartEntry);
        }
        return output;
    }

    public async Task<bool> AddToCartAsync(CartRequest request)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var cartEntry = await _db.Carts
            .Where(c => c.CustomerId == customerId && c.ItemId == request.ItemId)
            .FirstOrDefaultAsync();

        if(cartEntry == null)
        {
            if (request.Amount < 0)
            {
                return false;
            }

            var cartModel = _mapper.Map<CartRequest, Cart>(request);
            cartModel.CustomerId = customerId;
            _db.Carts.Add(cartModel);
        }
        else
        {
            cartEntry.Amount += request.Amount;
            if (cartEntry.Amount < 0)
            {
                _db.Carts.Remove(cartEntry);
            }
        }

        var rowsAffected = await _db.SaveChangesAsync();
        return rowsAffected == 1;
    }

    public async Task<bool> UpdateCartAsync(CartRequest request)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var cartEntity = await _db.Carts
            .Where(c => c.CustomerId == customerId && c.ItemId == request.ItemId)
            .Include(c => c.Item)
            .FirstAsync();

        if (cartEntity.Item.Amount < request.Amount)
        {
            return false;
        }

        if (request.Amount <= 0)
        {
            _db.Carts.Remove(cartEntity);
        }

        cartEntity.Amount = request.Amount;

        var rowsAffected = await _db.SaveChangesAsync();
        return true;
    }

    public async Task DeleteFromCartAsync(int itemId)
    {
        var customerId = await _userService.GetCustomerIdAsync();
        var cartEntry = _db.Carts.Where(x => x.CustomerId == customerId && x.ItemId == itemId).First();
        _db.Carts.Remove(cartEntry);
        await _db.SaveChangesAsync();
    }
}
