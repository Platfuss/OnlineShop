using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [RegularExpression("^\\d{2}-\\d{3}$")]
        public string PostalCode { get; set; }
    }
}
