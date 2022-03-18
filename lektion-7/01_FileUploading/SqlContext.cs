using _01_FileUploading.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _01_FileUploading
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ImageEntity> Images { get; set; }
    }
}
