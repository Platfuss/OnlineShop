namespace DataAccess.Models.Dto.Responses;

public class SingleItemResponse
{
    public virtual int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public uint Amount { get; set; }

    public string Category { get; set; }

    public DateTime AddedToShop { get; set; }

    public List<byte[]> Images { get; set; }
}
