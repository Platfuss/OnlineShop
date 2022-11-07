namespace DataAccess.Models.Dto;

public class CartResponse
{
    public int ItemId { get; set; }
    public uint Amount { get; set; }
    public byte[] Image { get; set; }
}
