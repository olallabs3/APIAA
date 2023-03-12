using Microsoft.EntityFrameworkCore;

namespace APIAA.Models{

    public class VideojuegoContext : DbContext{

        public VideojuegoContext(DbContextOptions<VideojuegoContext>options)
        :base (options){

        }
        public DbSet<Videojuego> Videojuegos {get; set; } = null!;
        public DbSet<Usuario> Usuarios {get; set; } = null!;
        public DbSet<Transaccion> Transacciones {get; set; } = null!;
        public DbSet<Biblioteca> Bibliotecas {get; set;} = null!;
    
        /*EFcore modelo de la relación N-M*/
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Videojuegos) //u es cada uno de todos los usuarios
            .WithMany(u => u.Usuarios)
            .UsingEntity<Biblioteca>(
                b => b   //b es cada uno de los registros de la biblioteca
                    .HasOne(uv => uv.Videojuego)    //uv es la "combinación de las tablas"
                    .WithMany(v => v.Bibliotecas)
                    .HasForeignKey(uv => uv.VideojuegoId),
                b => b
                    .HasOne(uv => uv.Usuario)
                    .WithMany(u => u.Bibliotecas)
                    .HasForeignKey(uv => uv.UsuarioId),
                b =>
                {
                    b.HasKey(v => new {v.UsuarioId, v.VideojuegoId});
                }
            );
        }
            
    }
}