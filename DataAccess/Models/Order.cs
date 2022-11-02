using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceAddressId { get; set; }
        public int ShipmentAddressId { get; set; }
        public string ShipmentType { get; set; }
    }
}
