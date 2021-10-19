using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Data.EntityTypeConfiguration
{
    public class ConferenceConfiguration : IEntityTypeConfiguration<Conference.Models.Conference>
    {
        public void Configure(EntityTypeBuilder<Models.Conference> builder)
        {
            builder.ToTable("Conference").HasKey(c => new { c.Id });
        }
    }
}
