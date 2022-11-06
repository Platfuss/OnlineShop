using DataAccess.Models.Database;
using DataAccess.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemsService;

    public ItemsController(IItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet("GetItem/{id}")]
    public async Task<ItemDto> GetItem(int id)
    {
        return await _itemsService.GetItemAsync(id);
    }

    [HttpGet("GetAllItems")]
    public async Task<IEnumerable<ItemDto>> GetAllItems()
    {
        return await _itemsService.GetItemsAllAsync();
    }

    [HttpGet("GetItemsInCategory/{categoryName}")]
    public async Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName)
    {
        return await _itemsService.GetItemsInCategoryAsync(categoryName);
    }

    [HttpGet("GetNewestItems")]
    public async Task<IEnumerable<ItemDto>> GetNewestItems()
    {
        return await _itemsService.GetNewestItemsAsync();
    }

    [HttpPost("InsertItem")]
    public async Task<Item> InsertItem(Item model)
    {
        return await _itemsService.InsertItemAsync(model);
    }

    [HttpPatch("UpdateItem")]
    public async Task<Item> UpdateItem(Item model)
    {
        return await _itemsService.UpdateItemAsync(model);
    }

    [HttpDelete("DeleteItem/{id}")]
    public async Task DeleteItem(int id)
    {
        await _itemsService.DeleteItemAsync(id);
    }
}
