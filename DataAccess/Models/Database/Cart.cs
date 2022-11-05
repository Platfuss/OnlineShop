using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Database
{
    public class Cart
    {
        public int Id { get; set; }

        public virtual int CustomerId { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public virtual int ItemId { get; set; }
        [Required]
        public virtual Item Item { get; set; }

        public int Amount { get; set; }
    }
}
