using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class Cart
{
    public int Id { get; set; } = 0;

    public int CustomerId { get; set; } = 0;
    [JsonIgnore]
    public virtual Customer Customer { get; set; }

    public int ItemId { get; set; } = 0;
    [JsonIgnore]
    public virtual Item Item { get; set; }

    public uint Amount { get; set; } = 0;
}
