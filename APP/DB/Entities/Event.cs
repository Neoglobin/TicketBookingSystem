using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public string Location { get; set; } = string.Empty;
    }
}
