using exemploBlobAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace exemploBlobAzure.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
    }
}
