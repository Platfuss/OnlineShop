namespace DataAccess.Models.Database;
public class CustomerAddress
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
}
