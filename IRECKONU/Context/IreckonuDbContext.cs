using IRECKONU.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRECKONU.Context
{
    public class IreckonuDbContext : DbContext
    {
        public IreckonuDbContext(DbContextOptions options) : base(options)
        {
         
        }

        public DbSet<Article> Articles { get; set; }
    }
}