using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;

namespace DB.Entities
{
    public class Order : BaseEntity, IEntityOperation
    {
        public Guid UserId { get; set; } = Guid.Empty;
        
        public User? User { get; set; }

        public Guid EventId { get; set; } = Guid.Empty;

        public Event? Event { get; set; }

        public Guid SeatId { get; set; } = Guid.Empty;

        public Seat? Seat { get; set; }

        public Guid StatusId { get; set; } = Guid.Empty;

        public OrderStatus? Status { get; set; }

        public new async Task<bool> SaveAsync(AppDbContext dbContext)
        {
            return await base.SaveAsync(dbContext);
        }
    }
}
