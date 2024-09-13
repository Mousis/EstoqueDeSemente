using EstoqueDeSemente.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueDeSemente.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
