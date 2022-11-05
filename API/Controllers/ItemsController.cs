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
        return await _itemsService.GetItem(id);
    }

    [HttpGet("GetAllItems")]
    public async Task<IEnumerable<ItemDto>> GetAllItems()
    {
        return await _itemsService.GetItemsAll();
    }

    [HttpGet("GetItemsInCategory/{categoryName}")]
    public async Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName)
    {
        return await _itemsService.GetItemsInCategory(categoryName);
    }

    [HttpGet("GetNewestItems")]
    public async Task<IEnumerable<ItemDto>> GetNewestItems()
    {
        return await _itemsService.GetNewestItems();
    }

    [HttpPost("InsertItem")]
    public async Task<Item> InsertItem(Item model)
    {
        return await _itemsService.InsertItem(model);
    }

    [HttpPatch("UpdateItem")]
    public async Task<Item> UpdateItem(Item model)
    {
        return await _itemsService.UpdateItem(model);
    }

    [HttpDelete("DeleteItem/{id}")]
    public async Task DeleteItem(int id)
    {
        await _itemsService.DeleteItem(id);
    }
}
