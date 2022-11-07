using DataAccess.Models.Database;
using DataAccess.Models.Dto.Helpers;

namespace DataAccess.Models.Dto;
public class OrderInfo
{
    public int Id { get; set; }

    public Address InvoiceAddress { get; set; }

    public Address ShipingAddress { get; set; }

    public DateTime CreationDate { get; set; }

    public string ShipmentType { get; set; }

    public List<BoughtItem> OrderedItems { get; set; }
}
