﻿using DataAccess.Miscellaneous;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{id}")]
    public async Task<ItemDto> GetItem(int id)
    {
        return await _itemsService.GetItemAsync(id);
    }

    [HttpGet("all-items")]
    public async Task<IEnumerable<ItemDto>> GetAllItems()
    {
        return await _itemsService.GetItemsAllAsync();
    }

    [HttpGet("category/{categoryName}")]
    public async Task<IEnumerable<ItemDto>> GetItemsInCategory(string categoryName)
    {
        return await _itemsService.GetItemsInCategoryAsync(categoryName);
    }

    [HttpGet("newests")]
    public async Task<IEnumerable<ItemDto>> GetNewestItems()
    {
        return await _itemsService.GetNewestItemsAsync();
    }

    [HttpPost("add"), Authorize(Roles = Roles.Owner)]
    public async Task<Item> InsertItem(Item model)
    {
        return await _itemsService.InsertItemAsync(model);
    }

    [HttpPatch("update"), Authorize(Roles = Roles.Owner)]
    public async Task<Item> UpdateItem(Item model)
    {
        return await _itemsService.UpdateItemAsync(model);
    }
}
