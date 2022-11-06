using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Order
{
    public int Id { get; set; } = 0;

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    public string ShipmentType { get; set; }

    public int CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }

    public int InvoiceAddressId { get; set; }
    [JsonIgnore]
    public virtual Address InvoiceAddress { get; set; }

    public int ShipingAddressId { get; set; }
    [JsonIgnore]
    public virtual Address ShipingAddress { get; set; }
}
