using Microsoft.EntityFrameworkCore;

namespace APIAA.Models{

    public class VideojuegoContext : DbContext{

        public VideojuegoContext(DbContextOptions<VideojuegoContext>options)
        :base (options){

        }
        public DbSet<Videojuego> Videojuegos {get; set; } = null!;
        public DbSet<Usuario> Usuarios {get; set; } = null!;
    }
}