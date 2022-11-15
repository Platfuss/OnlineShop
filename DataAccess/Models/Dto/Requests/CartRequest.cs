using System.Text.Json.Serialization;

namespace DataAccess.Models.Dto.Requests;
public class CartRequest
{
    public int ItemId { get; set; }
    public uint Amount { get; set; }
}
