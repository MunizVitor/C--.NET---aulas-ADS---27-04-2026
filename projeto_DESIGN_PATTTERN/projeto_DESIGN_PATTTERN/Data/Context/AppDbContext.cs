using Microsoft.EntityFrameworkCore;
using projeto_DESIGN_PATTTERN.Models;

namespace projeto_DESIGN_PATTTERN.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
