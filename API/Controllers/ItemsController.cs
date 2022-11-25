using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
    public async Task<SingleItemResponse> GetItem(int id)
    {
        return await _itemsService.GetItemAsync(id);
    }

    [HttpGet("group/{amount}/{page}")]
    public async Task<IEnumerable<GroupedItemResponse>> GetAllItems(int amount, 
                                                                    int page,
                                                                    string category,
                                                                    bool onlyRecommended = false,
                                                                    bool descendingOrderByDate = true)
    {
        return await _itemsService.GetItemsByPagesAsync(amount, page, category, onlyRecommended, descendingOrderByDate);
    }

    [HttpGet("group/number-of-pages/{amountPerPage}")]
    public async Task<int> HowManyPages([Range(1, int.MaxValue)]int amountPerPage, string category, bool onlyRecommended = false)
    {
        return await _itemsService.HowManyPagesAsync(amountPerPage, category, onlyRecommended);
    }

}

//[HttpGet("category/{categoryName}")]
//public async Task<IEnumerable<SingleItemResponse>> GetItemsInCategory(string categoryName)
//{
//    return await _itemsService.GetItemsInCategoryAsync(categoryName);
//}

//[HttpGet("newests")]
//public async Task<IEnumerable<SingleItemResponse>> GetNewestItems()
//{
//    return await _itemsService.GetNewestItemsAsync();
//}



//[HttpPost("add"), Authorize(Roles = Roles.Owner)]
//public async Task<Item> InsertItem(Item model)
//{
//    return await _itemsService.InsertItemAsync(model);
//}

//[HttpPatch("update"), Authorize(Roles = Roles.Owner)]
//public async Task<Item> UpdateItem(Item model)
//{
//    return await _itemsService.UpdateItemAsync(model);
//}