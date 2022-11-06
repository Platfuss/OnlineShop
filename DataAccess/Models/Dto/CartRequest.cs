using System.Text.Json.Serialization;

namespace DataAccess.Models.Dto;
public class CartRequest
{
    [JsonIgnore]
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }
}
