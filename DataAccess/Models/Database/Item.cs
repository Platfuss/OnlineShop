using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Database;

public class Item
{
    public int Id { get; set; } = 0;
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    public int Amount { get; set; }

    public string Category { get; set; }

    [Required]
    public DateTime AddedToShop { get; set; } = DateTime.UtcNow;
}
