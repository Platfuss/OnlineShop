using DataAccess.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Converters
{
    public static class ItemConverter
    {
        public static ItemDto ModelToDto(ItemModel model, List<byte[]>? images)
        {
            var modelDto = new ItemDto() { Id = model.Id, Name = model.Name, Description = model.Description, Price = model.Price,
                Amount = model.Amount, Category = model.Category, Images = images, AddedToShop = model.AddedToShop};

            return modelDto;
        }
    }
}
