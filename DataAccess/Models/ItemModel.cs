﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        public string Category { get; set; }
        public string? ImagePaths { get; set; }
        public DateTime AddedToShop { get; set; }
    }
}
