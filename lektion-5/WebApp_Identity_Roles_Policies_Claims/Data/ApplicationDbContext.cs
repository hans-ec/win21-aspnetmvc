using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Identity_Roles_Policies_Claims.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationAddress> Addresses { get; set; }
        public virtual DbSet<ApplicationUserAddress> UserAddresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserAddress>()
                .HasKey(c => new { c.UserId, c.AddressId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey("LoginProvider", "ProviderKey");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey("UserId", "RoleId");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey("UserId", "LoginProvider", "Name");

        }
    }
}