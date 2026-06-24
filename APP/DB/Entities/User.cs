using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;

namespace DB.Entities
{
    public class User : BaseEntity, IEntityOperation
    {
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        
        public new async Task<bool> SaveAsync(AppDbContext dbContext)
        {
            return await base.SaveAsync(dbContext);
        }
    }
}
