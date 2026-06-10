using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Seat : BaseEntity
    {
        public Event? Event { get; set; }

        public int Row { get; set; } = 0;

        public string Number { get; set; } = string.Empty;

        public SeatStatus? Status { get; set; }
    }
}
