using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Order
{
    public int Id { get; set; } = 0;

    public int CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }

    public int InvoiceAddressId { get; set; }
    [JsonIgnore]
    public virtual Address InvoiceAddress { get; set; }

    public int ShippingAddressId { get; set; }
    [JsonIgnore]
    public virtual Address ShippingAddress { get; set; }

    [JsonIgnore]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    [Required]
    public string PaymentType { get; set; } = "Gotówka";

    [Required]
    public string Status { get; set; } = "Złożone";

    [Required]
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    [Required]
    public string ShipmentType { get; set; }
}
