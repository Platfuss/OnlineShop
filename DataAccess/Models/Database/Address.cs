using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Database
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        public string SubNumber { get; set; }

        [Required, RegularExpression("^\\d{2}-\\d{3}$")]
        public string PostalCode { get; set; }
    }
}
