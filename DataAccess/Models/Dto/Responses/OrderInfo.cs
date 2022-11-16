using DataAccess.Models.Database;
using DataAccess.Models.Dto.Helpers;

namespace DataAccess.Models.Dto.Responses;
public class OrderInfo
{
    public int Id { get; set; }

    public Address InvoiceAddress { get; set; }

    public Address ShippingAddress { get; set; }

    public DateTime CreationDate { get; set; }

    public string Status { get; set; }

    public decimal TotalPrice { get; set; }

    public string ShipmentType { get; set; }

    public string PaymentType { get; set; }

    public List<BoughtItem> OrderedItems { get; set; }
}
