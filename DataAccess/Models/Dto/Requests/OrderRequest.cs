using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models.Dto.Requests;
public class OrderRequest
{
    public int InvoiceAddressId { get; set; }

    public int ShippingAddressId { get; set; }

    [JsonIgnore]
    public int CustomerId { get; set; }

    [Required]
    public string ShipmentType { get; set; }

    [Required]
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}
