using FullStackApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackApi.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
