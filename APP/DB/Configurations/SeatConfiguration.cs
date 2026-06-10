using DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}

