using _02_Modified_AspNetMvc.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_Modified_AspNetMvc
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}
