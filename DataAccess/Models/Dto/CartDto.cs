using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        public byte[] Image { get; set; }
    }
}
