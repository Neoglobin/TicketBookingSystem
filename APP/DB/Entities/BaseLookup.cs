using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public abstract class BaseLookup : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
