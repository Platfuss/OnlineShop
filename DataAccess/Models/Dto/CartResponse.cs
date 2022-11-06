namespace DataAccess.Models.Dto;

public class CartResponse
{
    public int ItemId { get; set; }
    public int Amount { get; set; }
    public byte[] Image { get; set; }
}
