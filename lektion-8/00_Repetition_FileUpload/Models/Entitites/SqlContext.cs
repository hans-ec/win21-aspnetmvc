using Microsoft.EntityFrameworkCore;

namespace _00_Repetition_FileUpload.Models.Entitites
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ProfileImageEntity> ProfileImages { get; set; }
        public virtual DbSet<UserProfileEntity> UserProfiles { get; set; }
    }
}
