using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public Guid ModifiedBy { get; set; }
        
        public void SetEntityDefValues()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }

        public async Task<bool> SaveAsync(AppDbContext dbContext)
        {
            await dbContext.AddAsync(this);
            return (await dbContext.SaveChangesAsync() > 0);
        }
    }
}
