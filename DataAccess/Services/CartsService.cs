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
        var customerId = await GetCustomerIdAsync();
        var userCart = await _db.Carts.Where(cart => cart.CustomerId == customerId).ToListAsync();
        var output = new List<CartResponse>();
        foreach (var item in userCart)
        {
            var image = (await _fileService.ReadAsync(item.Id.ToString(), onlyFirst: true))
                .FirstOrDefault();
            var cartEntry = _mapper.Map<Cart, CartResponse>(item, opt => opt.AfterMap((src, dest) => dest.Image = image));
            output.Add(cartEntry);
        }
        return output;
    }

    public async Task<bool> AddToCartAsync(CartRequest request)
    {
        var cartModel = _mapper.Map<CartRequest, Cart>(request);
        cartModel.CustomerId = await GetCustomerIdAsync();
        _db.Carts.Add(cartModel);
        await _db.SaveChangesAsync();
        return cartModel.Id != 0;
    }

    public async Task<List<string>> ValidateAmountOfItemsAsync()
    {
        var customerId = await GetCustomerIdAsync();
        var itemsInCart = await _db.Carts.Include(c => c.Item).Where(c => c.CustomerId == customerId).ToListAsync();
        var notEnoughItems = new List<string>();

        foreach (var wantedItem in itemsInCart)
        {
            if (wantedItem.Amount > wantedItem.Item.Amount)
            {
                notEnoughItems.Add(wantedItem.Item.Name);
            }
        }

        return notEnoughItems;
    }

    public async Task<bool> UpdateCartAsync(CartRequest request)
    {
        var customerId = await GetCustomerIdAsync();
        var cartEntity = await _db.Carts
            .Where(c => c.CustomerId == customerId && c.ItemId == request.ItemId)
            .FirstAsync();
        cartEntity.Amount = request.Amount;
        await _db.SaveChangesAsync();
        return cartEntity.Amount == request.Amount;
    }

    public async Task DeleteFromCartAsync(int itemId)
    {
        var customerId = await GetCustomerIdAsync();
        var cartEntry = _db.Carts.Where(x => x.CustomerId == customerId && x.ItemId == itemId).First();
        _db.Carts.Remove(cartEntry);
        await _db.SaveChangesAsync();
    }

    private async Task<int> GetCustomerIdAsync() => (await _userService.GetCustomerAsync()).Id;
}
