using ApiExamen.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiExamen.Data
{
    public class VideojuegoContext : DbContext
    {
        public VideojuegoContext(DbContextOptions<VideojuegoContext> options) :base(options)
        {

        }

        public DbSet<Videojuego> videojuegos { get; set; }

    }
}
