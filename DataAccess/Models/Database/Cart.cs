using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Cart
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }

    public int ItemId { get; set; }
    [JsonIgnore]
    public virtual Item Item { get; set; }

    public int Amount { get; set; }
}
