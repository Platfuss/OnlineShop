namespace DataAccess.Models.Database;

public class OrderDetail
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    public int ItemId { get; set; }
    public virtual Item Item { get; set; }
}
