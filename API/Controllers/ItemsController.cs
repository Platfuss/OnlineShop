using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsService _itemsService;
        private readonly IFileService _fileService;

        public ItemsController(IItemsService itemsService, IFileService fileService)
        {
            _itemsService = itemsService;
            _fileService = fileService;
        }

        [HttpGet("GetItem/{id}")]
        public async Task<ItemModel> GetItem(int id)
        {
            return await _itemsService.GetItem(id);
        }

        [HttpGet("GetAllItems")]
        public async Task<IEnumerable<ItemModel>> GetAllItems()
        {
            return await _itemsService.GetItemsAll();
        }

        [HttpGet("GetItemsInCategory/{categoryName}")]
        public async Task<IEnumerable<ItemModel>> GetItemsInCategory(string categoryName)
        {
            return await _itemsService.GetItemsInCategory(categoryName);
        }

        [HttpPost("InsertItem")]
        public async Task<ItemModel> InsertItem([FromForm] ItemModel model, [FromForm] List<string> dir, [FromForm] List<IFormFile> files)
        {
            _fileService.Save(dir, files);
            return await _itemsService.InsertItem(model);
        }

        [HttpPost("AbcdEF")]
        public async Task<List<byte[]>> ABCDEF([FromForm] ItemModel model, [FromForm] List<string> dir)
        {
            return await _fileService.Read(dir, false);
        }

        [HttpPatch("UpdateItem")]
        public async Task<ItemModel> UpdateItem(ItemModel model)
        {
            return await _itemsService.UpdateItem(model);
        }

        [HttpDelete("DeleteItem/{id}")]
        public async Task DeleteItem(int id)
        {
            await _itemsService.DeleteItem(id);
        }
    }
}
