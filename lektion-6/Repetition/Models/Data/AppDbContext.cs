using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repetition.Models.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AddressEntity> AspNetAddresses { get; set; }
        public virtual DbSet<ProfileEntity> AspNetProfiles { get; set; }
        public virtual DbSet<UserProfileEntity> AspNetUserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<UserProfileEntity>()
                .HasKey(c => new { c.UserId, c.ProfileId });

            builder.Entity<ProfileEntity>()
                .HasOne(e => e.Address)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
