using Conference.Data.EntityTypeConfiguration;
using Conference.Models;
using Microsoft.EntityFrameworkCore;


namespace Conference.Data
{
    public class ConferenceDbContext : DbContext
    {
        public virtual DbSet<Conference.Models.Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceXAttendee> ConferenceXAttendees { get; set; }

        public ConferenceDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConferenceXAttendeeConfiguration());
            modelBuilder.ApplyConfiguration(new ConferenceConfiguration());
        }
    }
}
