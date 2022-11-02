using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Item
    {
        public virtual int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required, Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime AddedToShop { get; set; }
    }
}
