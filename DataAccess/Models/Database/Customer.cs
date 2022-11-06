using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Customer
{
    public int Id { get; set; } = 0;

    public string Name { get; set; }

    public string Surname { get; set; }

    public int? DefaultInvoiceAddressId { get; set; }
    [JsonIgnore]
    public virtual Address DefaultInvoiceAddress { get; set; }

    public int? DefaultShipingAddressId { get; set; }
    [JsonIgnore]
    public virtual Address DefaultShipingAddress { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}
