using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Database;

public class Order
{
    public int Id { get; set; }

    [Required]
    public Customer Customer { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    public string ShipmentType { get; set; }

    public int InvoiceAddressId { get; set; }
    public virtual Address InvoiceAddress { get; set; }

    public int ShippingAddressId { get; set; }
    public virtual Address ShippingAddress { get; set; }
}
