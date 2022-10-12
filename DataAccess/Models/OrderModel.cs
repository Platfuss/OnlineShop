using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int InvoiceAdressId { get; set; }
        public int ShipmentAdressId { get; set; }
        public string ShipmentType { get; set; }
    }
}
