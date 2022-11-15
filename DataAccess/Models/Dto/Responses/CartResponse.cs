namespace DataAccess.Models.Dto.Responses;

public class CartResponse
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint Amount { get; set; }
    public byte[] Image { get; set; }
}
