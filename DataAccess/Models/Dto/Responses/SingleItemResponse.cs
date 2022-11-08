using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models.Dto.Responses;

public class SingleItemResponse
{
    public virtual int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }

    public uint Amount { get; set; }

    public string Category { get; set; }

    [Required]
    public DateTime AddedToShop { get; set; }

    [Required]
    public List<byte[]> Images { get; set; }
}
