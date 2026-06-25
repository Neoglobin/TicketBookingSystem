using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Seat : BaseEntity
    {
        public Guid EventId { get; set; } = Guid.Empty;
        
        public Event? Event { get; set; }

        public int Row { get; set; } = 0;

        public int Number { get; set; } = 0;

        public Guid StatusId { get; set; } = Guid.Empty;
        
        public SeatStatus? Status { get; set; }
    }
}
