using Microsoft.EntityFrameworkCore;

namespace ApiSistema.Models
{
    public class DeudasContext:DbContext
    {
        public DeudasContext(DbContextOptions<DeudasContext> options)
     : base(options)
        {
        }

        public DbSet<Deudas> TodoItems { get; set; } = null!;
    }
}


