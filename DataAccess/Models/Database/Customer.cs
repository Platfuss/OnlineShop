using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Customer
{
    public int Id { get; set; } = 0;

    public string Name { get; set; }

    public string Surname { get; set; }

    [JsonIgnore]
    public virtual ICollection<Address> Addresses { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }

    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; set; }
}
