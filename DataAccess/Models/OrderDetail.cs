using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public virtual int ItemId { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
