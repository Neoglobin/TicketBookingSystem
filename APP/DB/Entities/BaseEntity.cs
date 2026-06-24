using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;

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
            if (this.Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            
            CreatedOn = this.CreatedOn == default ? DateTime.UtcNow : this.CreatedOn;
            ModifiedOn = DateTime.UtcNow;
        }

        protected async Task<bool> SaveAsync(AppDbContext dbContext)
        {
            if (this.Id != Guid.Empty)
            {
                SetEntityDefValues();
                await Task.Run(() =>
                {
                    dbContext.Update(this);
                });
            }
            else
            {
                SetEntityDefValues();
                await dbContext.AddAsync(this);
            }
            
            return (await dbContext.SaveChangesAsync() > 0);
        }
    }
}
