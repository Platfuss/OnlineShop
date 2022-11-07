using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class OrderDetail
{
    public int Id { get; set; } = 0;

    public int OrderId { get; set; }
    [JsonIgnore]
    public virtual Order Order { get; set; }

    public int ItemId { get; set; }
    [JsonIgnore]
    public virtual Item Item { get; set; }

    public uint Amount { get; set; }
}
