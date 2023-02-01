using Microsoft.EntityFrameworkCore;

namespace APIAA.Models{

    public class VideojuegoContext : DbContext{

        public VideojuegoContext(DbContextOptions<VideojuegoContext>options)
        :base (options){

        }
        DbSet<Videojuego> Videojuegos {get; set; } = null!;
    }
}