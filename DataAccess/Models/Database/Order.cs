using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Database;

public class Order
{
    public int Id { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    public string ShipmentType { get; set; }

    public int CustomerId { get; set; } 
    public virtual Customer Customer { get; set; }

    public int InvoiceAddressId { get; set; }
    public virtual Address InvoiceAddress { get; set; }

    public int ShipingAddressId { get; set; }
    public virtual Address ShipingAddress { get; set; }
}
