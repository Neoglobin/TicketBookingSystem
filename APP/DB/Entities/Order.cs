using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Order : BaseEntity
    {
        public User? User { get; set; }

        public Event? Event { get; set; }

        public Seat? Seat { get; set; }

        public OrderStatus? Status { get; set; }
    }
}
