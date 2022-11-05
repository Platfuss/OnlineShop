using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Database;

public class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    [Required]
    public virtual Customer Customer { get; set; }

    public int ItemId { get; set; }
    [Required]
    public virtual Item Item { get; set; }

    public int Amount { get; set; }
}
