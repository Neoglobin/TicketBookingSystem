using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;

namespace DB.Entities
{
    public class Event : BaseEntity, IEntityOperation
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public string Location { get; set; } = string.Empty;

        public new async Task<bool> SaveAsync(AppDbContext dbContext)
        {
            return await base.SaveAsync(dbContext);
        }
    }
}
