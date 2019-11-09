using back.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Data
{
    public class SeguroDbContext: DbContext
    {
        public DbSet<Seguro> Seguros { get; set; }
        public SeguroDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}