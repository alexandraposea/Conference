﻿using Conference.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Data.EntityTypeConfiguration
{
    public class ConferenceXAttendeeConfiguration : IEntityTypeConfiguration<ConferenceXAttendee>
    {
        public void Configure(EntityTypeBuilder<ConferenceXAttendee> builder)
        {
            builder.ToTable("ConferenceXAttendee").HasKey(x => new { x.Id });
            builder.Property(c => c.AttendeeEmail);
            builder.Property(c => c.StatusId);
            builder.HasOne(c => c.Conference)
                .WithMany()
                .HasForeignKey(c => c.ConferenceId);
        }
    }
}
