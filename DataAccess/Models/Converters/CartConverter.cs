using DataAccess.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Converters
{
    public static class CartConverter
    {
        public static CartDto ModelToDto(CartModel model, byte[] image)
        {
            return new CartDto()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                ItemId = model.ItemId,
                Amount = model.Amount,
                Image = image
            };
        }
    }
}
